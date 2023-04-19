using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Interfaces.Services;

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
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO dto)
        {
            var result = await _productService.Create(dto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO dto)
        {
            await _productService.Update(dto);
            return Ok();
        }
    }
}
