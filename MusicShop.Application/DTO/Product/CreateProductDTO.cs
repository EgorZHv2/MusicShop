using MusicShop.Application.DTO.ProductPropertyValue;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Product
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ProductStatus ProductStatus { get; set; }
        [Required]
        public int   QuantityInStock { get; set; }
        public double? Discount { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        public List<ProductPropertyValueDTO> ProductPropertiesValues { get; set; } = new List<ProductPropertyValueDTO>();
    }
}
