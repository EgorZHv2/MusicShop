using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;
using MusicShop.WebAPI.Filters;
using MusicShop.Application.Exceptions;

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

        /// <summary>
        /// Создание категории
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
       
        [HttpPost]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> Create(CategoryCreateDTO dto)
        {
            var result = await _categoryService.Create(dto);
            return Ok(result);
        }
        /// <summary>
        /// Изменение категории
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
       
        [HttpPut]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> Update(CategoryUpdateDTO dto)
        {
            await _categoryService.Update(dto);
            return Ok();
        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
       
        [HttpDelete]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Получение страницы категорий
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        
        [HttpGet("get-page")]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> GetPage([FromQuery] PaginationDTO dto)
        {
            if (!ModelState.IsValid)
            {
                throw new CategoryNotFoundException();
            }
            var result = await _categoryService.GetPage(dto);
            return Ok(result);
        }
        /// <summary>
        /// Получение категории по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("{id}")]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Получение короткого списка категорий
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("get-short")]
        public async Task<IActionResult> GetShort()
        {
            var result = await _categoryService.GetShortList();
            return Ok(result);
        }

    }
}
