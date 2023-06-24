using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Application.DTO.Identity;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Enums;
using MusicShop.WebAPI.Filters;

namespace MusicShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
          
            var result = await _authService.Login(model);
            return Ok(result);
        }
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            await _authService.Register(model);
            return Ok();
        }

         /// <summary>
        /// Регистрация нового администоратора
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPost("register-admin")]
        [CustomAuthorize(UserRole.Admin)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDTO model)
        {
            await _authService.Register(model,UserRole.Admin);
            return Ok();
        }
        /// <summary>
        /// Смена пароля
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Успех</response>
        /// <response code="401">Неавторизирован</response>
        /// <response code="500">Ошибка сервера</response>
        [HttpPatch("change-password")]
        [CustomAuthorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
           
            await _authService.ChangePassword(model);
            return Ok();
        }
    }
}
