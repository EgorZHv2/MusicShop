using MusicShop.Application.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginDTO dto);
        Task Register(RegisterDTO dto);
        Task ChangePassword(ChangePasswordDTO dto);
    }
}
