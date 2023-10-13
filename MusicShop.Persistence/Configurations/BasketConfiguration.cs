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
    public class BasketConfiguration:IEntityTypeConfiguration<BasketEntity>
    {
        public void Configure(EntityTypeBuilder<BasketEntity> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.HasOne(basket => basket.User)
                .WithOne(user => user.Basket)
                .HasForeignKey<BasketEntity>(basket => basket.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
