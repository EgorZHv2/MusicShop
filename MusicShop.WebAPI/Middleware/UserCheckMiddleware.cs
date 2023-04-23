using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Options;
using System.Globalization;
using System.Security.Claims;

namespace MusicShop.WebAPI.Middleware
{
    public class UserCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public UserCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,IUserRepository userRepository,ITokenService tokenService,UserData userData)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if(!string.IsNullOrEmpty(token))
            {
                var claims = tokenService.DecryptToken(token);
                var userEmail = claims.FirstOrDefault(e => e.Type == ClaimTypes.Name)?.Value;
                var user = await userRepository.GetUserByEmail(userEmail);
                userData.Email = user.Email;
                userData.Id = user.Id;
                userData.Role = user.Role;

            }
            await _next.Invoke(context);
        }
    }
}
