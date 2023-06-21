using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Address;
using MusicShop.Application.Interfaces.Services;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost]
        [Authorize]
      
        public async Task<IActionResult> Create(AddressCreateDTO dto)
        {
            var result = await _addressService.Create(dto);
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _addressService.GetById(id);
            return Ok(result);
        }
        [HttpGet("last-order-address")]
        [Authorize]
        public async Task<IActionResult> GetLastByUser()
        {
            var result = await _addressService.GetLastAddressByUserId();
            return Ok(result);
        }
    }
}
