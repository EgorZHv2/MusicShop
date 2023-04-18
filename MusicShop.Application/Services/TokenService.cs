using Microsoft.IdentityModel.Tokens;
using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace MusicShop.Application.Services
{
    public class TokenService
    {
        public string GetToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("devSecretKey"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                
            };
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials
            );
            return tokenHandler.WriteToken(token);
        }

        public List<Claim> DecryptToken(string token)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(token);
            var result = jwt.Claims.ToList();
            return result;
        }
    }
}
