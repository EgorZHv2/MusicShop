using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Filters.Product;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;

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
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> Create(ProductCreateDTO dto)
        {
            var result = await _productService.Create(dto);
            return Ok(result);
        }
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> Update(ProductUpdateDTO dto)
        {
            await _productService.Update(dto);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);
            return Ok();
        }
        [HttpPost("get-page")]
        public async Task<IActionResult> GetPage([FromBody]ProductFilter filter ,[FromQuery] PaginationDTO dto)
        {
            var result = await _productService.GetPage(filter,dto);
            return Ok(result);
        }
    }
}
