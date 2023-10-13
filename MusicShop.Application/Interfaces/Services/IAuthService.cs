using MusicShop.Application.DTO.Identity;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginDTO dto);
        Task Register(RegisterDTO dto, UserRole role = UserRole.Buyer);
        Task ChangePassword(ChangePasswordDTO dto);
    }
}
