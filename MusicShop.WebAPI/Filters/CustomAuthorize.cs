using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicShop.Application.Exceptions;
using MusicShop.Domain.Enums;
using System.Diagnostics;
using System.Security.Claims;

namespace MusicShop.WebAPI.Filters
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        private List<string> allowRoles = new List<string>();
        public CustomAuthorize(params UserRole[] roles)
        {
            allowRoles = roles.Select(e=>e.ToString()).ToList();
        }
        public CustomAuthorize()
        {
            
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new NotAuthorizedException();
            }
            if (allowRoles.Any())
            {
                if (!allowRoles.Contains(context.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Role).Value))
                {
                    throw new WrongRoleException();
                }
            }
        }
    }
}
