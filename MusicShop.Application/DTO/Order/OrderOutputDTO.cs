using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Order
{
    public class OrderOutputDTO
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int Quantity { get; set; }
        public Guid AddressId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        
    }
}
