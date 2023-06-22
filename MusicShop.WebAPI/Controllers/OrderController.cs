using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Order;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(OrderCreateDTO dto)
        {
            var result = await _orderService.Create(dto);
            return Ok(result);
        }
        /// <summary>
        /// Изменение статуса заказа
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPatch]
        [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Moderator)}")]
        public async Task<IActionResult> UpdateOrderStatus(OrderUpdateDTO dto)
        {
            await _orderService.UpdateOrderStatus(dto);
            return Ok();
        }
        /// <summary>
        /// Получение страницы заказов
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPage([FromQuery] PaginationDTO dto)
        {
            var result = await _orderService.GetPage(dto);
            return Ok(result);
        }
        /// <summary>
        /// Получение заказа по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _orderService.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Удаление заказа
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
            await _orderService.Delete(id);
            return Ok();
        }
    }
}
