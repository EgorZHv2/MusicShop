using Microsoft.Extensions.Localization;
using MusicShop.Application.DTO;
using MusicShop.Application.Exceptions;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Options;
using MusicShop.Domain.Resources.Localizations;
using System.Net;
using System.Security.Claims;

namespace MusicShop.WebAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IStringLocalizer<ExceptionsLocalizations> stringLocalizer)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(ApiException ex)
            {
                var a = stringLocalizer[ex.GetType().Name];
                ex.UserMessage = a.Value;
                await ResponseError(context, ex.UserMessage, ex.StatusCode);
            }
            catch(Exception ex) 
            {

            }
        }

        public async Task ResponseError(HttpContext context, string message, HttpStatusCode code = HttpStatusCode.InternalServerError)
        {
            context.Response.StatusCode = (int)code;
            context.Response.Headers["Content-Type"] = "application/json";
            await context.Response.WriteAsJsonAsync(new ErrorOutputDTO()
            {
                Message = message,
                StatusCode = (int)context.Response.StatusCode

            });
        }
    }
}
