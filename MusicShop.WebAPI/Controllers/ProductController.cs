using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Filters.Product;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;
using MusicShop.WebAPI.Filters;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Создание товара
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> Create(ProductCreateDTO dto)
        {
            var result = await _productService.Create(dto);
            return Ok(result);
        }
        /// <summary>
        /// Изменение товара
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        
        [HttpPut]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> Update(ProductUpdateDTO dto)
        {
            await _productService.Update(dto);
            return Ok();
        }
        /// <summary>
        /// Получение товара по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("{id}")]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Получение страницы товаров
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost("get-page")]
        public async Task<IActionResult> GetPage([FromBody]ProductFilter filter ,[FromQuery] PaginationDTO dto)
        {
            var result = await _productService.GetPage(filter,dto);
            return Ok(result);
        }
    }
}
