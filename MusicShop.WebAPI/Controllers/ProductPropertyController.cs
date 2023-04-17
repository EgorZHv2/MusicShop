using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.Interfaces.Services;

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
        [HttpGet("get-page")]
        public async Task<IActionResult> GetPage([FromQuery]PaginationDTO dto)
        {
            var result = await _productPropertyService.GetPage(dto);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductPropertyDTO dto)
        {
            var result = await _productPropertyService.Create(dto);
            return Ok(result);
        }
        [HttpGet("get-short")]
        public async Task<IActionResult> GetShort()
        {
            var result = await _productPropertyService.GetShortList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productPropertyService.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductPropertyDTO dto)
        {
            await _productPropertyService.Update(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productPropertyService.Delete(id);
            return Ok();
        }
    }
}
