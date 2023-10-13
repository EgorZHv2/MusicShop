using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class ReviewEntity:BaseEntity
    {
        public string ReviewText { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public ProductScore ProductScore { get; set; }
    }
}
