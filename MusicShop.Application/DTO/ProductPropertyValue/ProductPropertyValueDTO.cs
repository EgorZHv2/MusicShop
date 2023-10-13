using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.ProductPropertyValue
{
    public class ProductPropertyValueDTO
    {
        public Guid PropertyId { get; set; }
        public string? TextValue { get; set; }
        public double? NumericValue { get; set; }
        public bool? BoolValue { get; set; }
        public Guid? ValueFromSetId { get; set; }
    }
}
