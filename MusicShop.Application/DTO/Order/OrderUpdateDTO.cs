using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Order
{
    public class OrderUpdateDTO
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
