using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MusicShop.Application.DTO.Address;
using MusicShop.Application.Interfaces.Services;
using MusicShop.WebAPI.Filters;

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
        /// <summary>
        /// Создание адреса
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        [CustomAuthorize]
        public async Task<IActionResult> Create(AddressCreateDTO dto)
        {
            var result = await _addressService.Create(dto);
            return Ok(result);
        }
        /// <summary>
        /// Получение адреса по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
      
        [HttpGet("{id}")]
        [CustomAuthorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _addressService.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Получение адреса последнего заказа
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        
        [HttpGet("last-order-address")]
        [CustomAuthorize]
        public async Task<IActionResult> GetLastByUser()
        {
            var result = await _addressService.GetLastAddressByUserId();
            return Ok(result);
        }
    }
}
