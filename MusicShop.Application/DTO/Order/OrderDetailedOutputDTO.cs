using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Order
{
    public class OrderDetailedOutputDTO
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int Quantity { get; set; }
        public Guid AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Place { get; set; }
        public string Index { get; set; }
    }
}
