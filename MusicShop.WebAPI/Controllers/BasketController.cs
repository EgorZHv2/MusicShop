using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Services;
using MusicShop.WebAPI.Filters;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService= basketService;
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost("add-product-to-basket")]
        [CustomAuthorize]
        public async Task<IActionResult> AddProductToBasket(Guid productId) 
        {
            await _basketService.AddProductToBasket(productId);
            return Ok();
        }
        /// <summary>
        /// Удаление продукта из корзины
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("remove-product-from-basket")]
        [CustomAuthorize]
        public async Task<IActionResult> RemoveProductFromBasket(Guid productId)
        {
            await _basketService.RemoveProductFromBasket(productId);
            return Ok();
        }
        /// <summary>
        /// Очистка корзины
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("clear-basket")]
        [CustomAuthorize]
        public async Task<IActionResult> ClearBasket()
        {
            await _basketService.ClearBasket();
            return Ok();
        }
        /// <summary>
        /// Получение страницы продуктов в корзине
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("get-products-in-basket")]
        [CustomAuthorize]
        public async Task<IActionResult> GetProductsPage([FromQuery] PaginationDTO dto)
        {
            var result = await _basketService.GetProductsInBasket(dto);
            return Ok(result);
        }


    }
}
