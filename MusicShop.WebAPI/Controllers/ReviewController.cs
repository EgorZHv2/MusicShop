using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Review;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        /// <summary>
        /// Создание отзыва
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ReviewCreateDTO dto)
        {
            var result =  await _reviewService.Create(dto);
            return Ok(result);
        }
        /// <summary>
        /// Изменение отзыва
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(ReviewUpdateDTO dto)
        {
            await  _reviewService.Update(dto);
            return Ok();
        }
        /// <summary>
        /// Получение страницы отзывов по Id товара
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("by-product")]
        [Authorize]
       
        public async Task<IActionResult> GetPageByProductId([FromQuery] Guid productId,[FromQuery] PaginationDTO pagination)
        {
            var result = await _reviewService.GetPageByProductId(productId, pagination);
            return Ok(result);
        }
        /// <summary>
        /// Получение страницы отзывов по Id пользователя
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("by-user")]
        [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Moderator)}")]
        public async Task<IActionResult> GetPageByUserId([FromQuery] PaginationDTO pagination)
        {
            var result = await _reviewService.GetPageByUserId(pagination);
            return Ok(result);
        }
        /// <summary>
        /// Получение отзыва по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _reviewService.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reviewService.Delete(id);
            return Ok();
        }
    }
}
