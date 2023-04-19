using MusicShop.Application.DTO.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Category
{
    public class CategoryOutputDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductPropertyShortOutputDTO> ProductProperties { get; set; } = new List<ProductPropertyShortOutputDTO> ();
    }
}
