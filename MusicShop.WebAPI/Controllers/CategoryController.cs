using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Services;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO dto)
        {
            var result = await _categoryService.Create(dto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDTO dto)
        {
            await _categoryService.Update(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
        [HttpGet("get-page")]
        public async Task<IActionResult> GetPage([FromQuery] PaginationDTO dto)
        {
            var result = await _categoryService.GetPage(dto);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }
        [HttpGet("get-short")]
        public async Task<IActionResult> GetShort()
        {
            var result = await _categoryService.GetShortList();
            return Ok(result);
        }

    }
}
