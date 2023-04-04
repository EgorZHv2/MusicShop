using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Configurations
{
    public class ProductPropertySetConfiguration:IEntityTypeConfiguration<ProductPropertySetEntity>
    {
        public void Configure(EntityTypeBuilder<ProductPropertySetEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.ProductProperty)
                .WithMany(productProperty => productProperty.ProductPropertySet)
                .HasForeignKey(entity => entity.ProductPropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
