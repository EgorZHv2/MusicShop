using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class ProductPropertySetEntity
    {
        public Guid Id { get; set; }
        public ProductPropertyEntity ProductProperty { get; set; }
        public Guid ProductPropertyId { get; set; }
        public string Value { get; set; }
        public List<ProductPropertyValueEntity> ProductPropertyValues { get; set; }

    }
}
