using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Category
{
    public class CategoryCreateDTO
    {
        [Required]
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public List<Guid> PropertiesIds { get; set; } = new List<Guid>();
    }
}
