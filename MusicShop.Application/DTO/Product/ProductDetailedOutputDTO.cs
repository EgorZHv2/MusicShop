using MusicShop.Application.DTO.ProductPropertyValue;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Product
{
    public class ProductDetailedOutputDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public double? Discount { get; set; }
        public List<ProductPropertyValuetListOutputDTO> Properties { get; set; } = new List<ProductPropertyValuetListOutputDTO>();
        public string CategoryName { get; set; }
           
    }
}
