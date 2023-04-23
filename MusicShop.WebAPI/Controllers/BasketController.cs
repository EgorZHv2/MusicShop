using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Services;

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

        [HttpPost("add-product-to-basket")]
        [Authorize]
        public async Task<IActionResult> AddProductToBasket(Guid productId) 
        {
            await _basketService.AddProductToBasket(productId);
            return Ok();
        }

        [HttpDelete("remove-product-from-basket")]
        [Authorize]
        public async Task<IActionResult> RemoveProductFromBasket(Guid productId)
        {
            await _basketService.RemoveProductFromBasket(productId);
            return Ok();
        }
        [HttpDelete("clear-basket")]
        [Authorize]
        public async Task<IActionResult> ClearBasket()
        {
            await _basketService.ClearBasket();
            return Ok();
        }
        [HttpGet("get-products-in-basket")]
        [Authorize]
        public async Task<IActionResult> GetProductsPage([FromQuery] PaginationDTO dto)
        {
            var result = await _basketService.GetProductsInBasket(dto);
            return Ok(result);
        }


    }
}
