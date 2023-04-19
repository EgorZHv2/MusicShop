using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Review;
using MusicShop.Application.Interfaces.Services;

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
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ReviewCreateDTO dto)
        {
            var result =  await _reviewService.Create(dto);
            return Ok(result);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(ReviewUpdateDTO dto)
        {
            await  _reviewService.Update(dto);
            return Ok();
        }
        [HttpGet("by-product")]
        [Authorize]
       
        public async Task<IActionResult> GetPageByProductId([FromQuery] Guid productId,[FromQuery] PaginationDTO pagination)
        {
            var result = await _reviewService.GetPageByProductId(productId, pagination);
            return Ok(result);
        }
        [HttpGet("by-user")]
        [Authorize]
        public async Task<IActionResult> GetPageByUserId([FromQuery] PaginationDTO pagination)
        {
            var result = await _reviewService.GetPageByUserId(pagination);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _reviewService.GetById(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reviewService.Delete(id);
            return Ok();
        }
    }
}
