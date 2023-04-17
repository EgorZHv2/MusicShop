using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.PageModels;
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
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery]PaginationDTO dto)
        {
            var result = await _productPropertyService.GetPage(dto);
            return Ok(result);
        }
    }
}
