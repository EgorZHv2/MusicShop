using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Category
{
    public class UpdateCategoryDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public List<Guid> PropertiesIds { get; set; }
    }
}
