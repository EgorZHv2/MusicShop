using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Review
{
    public class ReviewUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Required]
        public ProductScore ProductScore { get; set; }
    }
}
