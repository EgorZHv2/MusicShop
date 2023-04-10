using MusicShop.Domain.Entities.ManyToManyTables;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class ProductPropertyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PropertyValueType ValueType { get; set; }

        public List<ProductEntity> Products { get; set; }
        public List<ProductPropertyValueEntity> ProductPropertiesValues { get; set; }
        public List<CategoryEntity> CategoryProperties { get; set; }
        public List<CategoryProductProperty> CategoryProductProperties { get; set; }
        public List<ProductPropertySetEntity> ProductPropertySet { get; set; }
    }
}
