﻿using MusicShop.Domain.Entities.ManyToManyTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class CategoryEntity:BaseEntity
    {
        public string Name { get; set; }
        public CategoryEntity? ParentCategory { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
        public List<ProductPropertyEntity> ProductProperties { get; set; } = new List<ProductPropertyEntity>();
        public List<CategoryProductProperty> CategoryProductProperties { get; set; } = new List<CategoryProductProperty>();
        public List<ProductEntity> Products { get; set; }

    }
}
