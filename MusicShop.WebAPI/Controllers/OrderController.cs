using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Order;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Services;

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

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDTO dto)
        {
            var result = await _orderService.Create(dto);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderStatus(OrderUpdateDTO dto)
        {
            await _orderService.UpdateOrderStatus(dto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] PaginationDTO dto)
        {
            var result = await _orderService.GetPage(dto);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _orderService.GetById(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderService.Delete(id);
            return Ok();
        }
    }
}
