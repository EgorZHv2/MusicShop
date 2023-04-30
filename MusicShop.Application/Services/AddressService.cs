using AutoMapper;
using MusicShop.Application.DTO.Address;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Services
{
    public class AddressService:IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly UserData _userData;
        public AddressService(
            IAddressRepository addressRepository,
            IMapper mapper,
            UserData userData
         )
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _userData = userData;
        }
        public async Task<Guid> Create(AddressCreateDTO dto)
        {
            var entity = _mapper.Map<AddressEntity>(dto);
            var result = await _addressRepository.Create(entity);
            return result;
        }
        public async Task<AddressOutputDTO> GetById(Guid id)
        {
            var entity = await _addressRepository.GetById(id);
            var result = _mapper.Map<AddressOutputDTO>(entity);
            return result;
        }
        public async Task<AddressOutputDTO> GetLastAddressByUserId()
        {
            var entity = await _addressRepository.GetLastAddressByUserId(_userData.Id);
            var result = _mapper.Map<AddressOutputDTO>(entity);
            return result;
        }
        
    }
}
