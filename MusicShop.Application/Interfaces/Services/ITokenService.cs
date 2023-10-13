using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GetToken(UserEntity user);
        List<Claim> DecryptToken(string token);
    }
}
