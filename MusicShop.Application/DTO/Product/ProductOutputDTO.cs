using MusicShop.Domain.Entities.ManyToManyTables;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Product
{
    public class ProductOutputDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public double? Discount { get; set; }
        public string CategoryName { get; set; }
    }
}
