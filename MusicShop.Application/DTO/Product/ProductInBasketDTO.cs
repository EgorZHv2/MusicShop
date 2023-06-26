using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Product
{
    public class ProductInBasketDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public double? Discount { get; set; }
    }
}
