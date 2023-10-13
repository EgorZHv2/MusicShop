using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class OrderEntity:BaseEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public ProductEntity Product { get; set; }
        public Guid ProductId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int Quantity { get; set; }

        public AddressEntity Address { get; set; }
        public Guid AddressId { get; set; }

    }
}
