using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities.ManyToManyTables
{
    public class CategoryProductProperty
    {
        public ProductPropertyEntity ProductProperty { get;set; }
        public Guid ProductPropertyId { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
