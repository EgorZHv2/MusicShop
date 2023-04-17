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
    public class ProductPropertyConfuguration:IEntityTypeConfiguration<ProductPropertyEntity>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
             entityTypeBuilder.HasQueryFilter(category => category.IsDeleted == false);
        }
    }
}
