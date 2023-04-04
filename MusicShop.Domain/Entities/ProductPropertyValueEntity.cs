
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class ProductPropertyValueEntity
    {
        public ProductEntity Product { get; set; }
        public Guid ProductId { get; set; }
        public ProductPropertyEntity Property { get; set; }
        public Guid PropertyId { get; set; }
        public string? TextValue { get; set; }
        public double? NumericValue { get; set; }
        public bool? BoolValue { get; set; }
        public Guid? ValueFromSetId { get; set; }

    }
}
