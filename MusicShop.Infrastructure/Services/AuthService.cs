using AutoMapper;
using DevOne.Security.Cryptography.BCrypt;
using MusicShop.Application.DTO.Identity;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserData _userData;
        public AuthService
        (
            IUserRepository userRepository,
            ITokenService tokenService,
            IMapper mapper,
            UserData userData
        ) 
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _userData = userData;
        }
        public async Task<string> Login(LoginDTO dto)
        {
            var user = await _userRepository.GetUserByEmail(dto.Email);
            if(user == null)
            {
                throw new Exception();
            }
            if (!BCryptHelper.CheckPassword(dto.Password, user.PasswordHash))
            {
                throw new Exception();
            }
            var result = _tokenService.GetToken(user);
            return result;
        }
        public async Task Register(RegisterDTO dto)
        {
            var existingUser = await _userRepository.GetUserByEmail(dto.Email);
            if(existingUser != null)
            {
                throw new Exception();
            }
            string salt = BCryptHelper.GenerateSalt(6);
            var user = _mapper.Map<UserEntity>(dto);
            user.PasswordHash = BCryptHelper.HashPassword(dto.Password, salt);
            await _userRepository.Create(user);
        }
         public async Task ChangePassword(ChangePasswordDTO dto)
        {
            var user = await _userRepository.GetById(_userData.Id);
            if(user == null)
            {
                throw new Exception();
            }
            if (!BCryptHelper.CheckPassword(dto.OldPassword, user.PasswordHash))
            {
                throw new Exception();
            }
            string salt = BCryptHelper.GenerateSalt(6);      
            user.PasswordHash = BCryptHelper.HashPassword(dto.Password, salt);
            await _userRepository.Update(user);
        }
    }
}
