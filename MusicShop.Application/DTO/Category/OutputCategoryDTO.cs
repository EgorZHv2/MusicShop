using MusicShop.Application.DTO.ProductProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Category
{
    public class OutputCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<OutputShortProductPropertyDTO> ProductProperties { get; set; } = new List<OutputShortProductPropertyDTO> ();
    }
}
