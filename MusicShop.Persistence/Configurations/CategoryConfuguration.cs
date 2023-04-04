using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Entities.ManyToManyTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Configurations
{
    public class CategoryConfuguration:IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(category => category.Id);

            entityTypeBuilder.HasMany(category => category.ProductProperties)
                .WithMany(productProp => productProp.CategoryProperties)
                .UsingEntity<CategoryProductProperties>(categoryProductPropeties =>
                {
                    categoryProductPropeties.HasOne(entity => entity.ProductProperty)
                    .WithMany(productProperty => productProperty.CategoryProductProperties)
                    .HasForeignKey(entity => entity.ProductPropertyId)
                    .OnDelete(DeleteBehavior.Cascade);
                    categoryProductPropeties.HasOne(entity => entity.Category)
                    .WithMany(category => category.CategoryProductProperties)
                    .HasForeignKey(entity => entity.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                    categoryProductPropeties.HasKey(entity => new {entity.ProductPropertyId, entity.CategoryId});
                    categoryProductPropeties.ToTable("CategoryProductProperties");
                });

            entityTypeBuilder.HasOne(category => category.ParentCategory)
                .WithMany(category => category.Categories)
                .HasForeignKey(category => category.ParentCategoryId)
                .OnDelete(DeleteBehavior.SetNull);
                
        }
    }
}
