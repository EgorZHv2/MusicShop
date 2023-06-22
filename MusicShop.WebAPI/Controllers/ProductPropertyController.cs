using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;
using System.Data;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertyController : ControllerBase
    {
        private readonly IProductPropertyService _productPropertyService;
        public ProductPropertyController(IProductPropertyService productPropertyService)
        {
            _productPropertyService= productPropertyService;
        }
        /// <summary>
        /// Получение страницы свойств товаров
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("get-page")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> GetPage([FromQuery]PaginationDTO dto)
        {
            var result = await _productPropertyService.GetPage(dto);
            return Ok(result);
        }
        /// <summary>
        /// Создание свойства товара
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> Create(ProductPropertyCreateDTO dto)
        {
            var result = await _productPropertyService.Create(dto);
            return Ok(result);
        }
        /// <summary>
        /// Получение короткого списка свойств товаров
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("get-short")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> GetShort()
        {
            var result = await _productPropertyService.GetShortList();
            return Ok(result);
        }
        /// <summary>
        /// Получение свойства товара по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("{id}")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productPropertyService.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Изменение свойства товаров
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> Update(ProductPropertyUpdateDTO dto)
        {
            await _productPropertyService.Update(dto);
            return Ok();
        }

        /// <summary>
        /// Удаление свойства товара
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productPropertyService.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Получение списка свойств товаров по Id категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("by-category-id/{id}")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> GetByCategoryId(Guid id)
        {
            var result = await _productPropertyService.GetPropertiesByCategoryId(Guid.NewGuid());
            return Ok(result);
        }
    }
}
