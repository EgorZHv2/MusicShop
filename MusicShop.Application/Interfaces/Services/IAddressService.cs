using MusicShop.Application.DTO.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IAddressService
    {
        Task<AddressOutputDTO> GetLastAddressByUserId();
            Task<AddressOutputDTO> GetById(Guid id);
            Task<Guid> Create(AddressCreateDTO dto);
    }
}
