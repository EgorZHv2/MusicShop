using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Identity
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Некорректный Email") ]
        public string Email { get; set; }

        [Required]
        [MinLength(8,ErrorMessage = "Пароль должен быть от 8 до 16 символов")]
        [MaxLength(16,ErrorMessage = "Пароль должен быть от 8 до 16 символов")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])([a-zA-Z0-9!@#$%^&*]{8,16})$",
            ErrorMessage = "Пароль должен содержать цифры, строчные и заглавные буквы латинского алфавита, а так же спецсимволы")]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
