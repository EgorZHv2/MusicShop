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
    public class OrderConfiguration:IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(order => order.Id);
            entityTypeBuilder.HasOne(order => order.User)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            entityTypeBuilder.HasOne(order => order.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(order => order.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            entityTypeBuilder.HasOne(order => order.Address)
                .WithMany(address => address.Orders)
                .HasForeignKey(order => order.AddressId);
                
        }
    }
}
