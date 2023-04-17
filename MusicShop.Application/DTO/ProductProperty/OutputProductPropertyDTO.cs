using MusicShop.Application.DTO.ProductPropertySet;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.ProductProperty
{
    public class OutputProductPropertyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PropertyValueType ValueType { get; set; }
        public List<OutputProductPropertySetDTO> ProductPropertySet { get; set; } = new List<OutputProductPropertySetDTO>();
        
    }
}
