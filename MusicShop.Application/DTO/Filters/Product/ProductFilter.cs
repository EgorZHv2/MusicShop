using MusicShop.Application.DTO.ProductPropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Filters.Product
{
    public class ProductFilter
    {
        public string? SearchQuery { get; set; }
        public decimal? MinPrice { get; set; } 
        public decimal? MaxPrice { get; set; } 
       
        public List<ProductPropertyValueFilterDTO> ProductPropertyValues { get; set; } = new List<ProductPropertyValueFilterDTO>();
    }
}
