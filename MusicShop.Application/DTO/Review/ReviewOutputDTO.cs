using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Review
{
    public class ReviewOutputDTO
    {
       
        public Guid Id { get; set; }
        public string ReviewText { get; set; }
        public ProductScore ProductScore { get; set; }
    }
}
