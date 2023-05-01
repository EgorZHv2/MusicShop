using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Address
{
    public class AddressCreateDTO
    {
        [Required]
        public string Country { get; set; } 
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Index { get; set; }
    }
}
