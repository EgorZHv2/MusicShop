using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Order
{
    public class OrderCreateDTO
    {
         public Guid ProductId { get; set; }
         public int Quantity { get; set; }
         public Guid AddressId { get; set; }
    }
}
