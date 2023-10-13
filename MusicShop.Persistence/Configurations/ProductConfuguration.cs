using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Entities.ManyToManyTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Configurations
{
    public class ProductConfuguration:IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(product => product.Id);
             entityTypeBuilder.HasQueryFilter(category => category.IsDeleted == false);
            entityTypeBuilder
                .HasMany(product => product.ProductProperties)
                .WithMany(product => product.Products)
                .UsingEntity<ProductPropertyValueEntity>(productPropertyValues =>
                {
                   productPropertyValues
                    .HasOne(entity => entity.Product)
                    .WithMany(product=>product.ProductPropertiesValues)
                    .HasForeignKey(entity=>entity.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
                    productPropertyValues
                     .HasOne(entity => entity.Property)
                     .WithMany(property => property.ProductPropertiesValues)
                     .HasForeignKey(entity => entity.PropertyId)
                     .OnDelete(DeleteBehavior.Cascade);

                    productPropertyValues.HasKey(entity => new {entity.ProductId, entity.PropertyId});

                    productPropertyValues.ToTable("ProductsPropertiesValues");

                    productPropertyValues
                        .HasOne(entity => entity.ProductPropertySetValue)
                        .WithMany(productPropertySet => productPropertySet.ProductPropertyValues)
                        .HasForeignKey(entity => entity.ValueFromSetId)
                        .OnDelete(DeleteBehavior.SetNull);
                });

            entityTypeBuilder
                .HasMany(product => product.Baskets)
                .WithMany(basket => basket.Products)
                .UsingEntity<ProductBasket>(basketProduct =>
                {
                    basketProduct.HasKey(entity => new { entity.ProductId, entity.BasketId });
                    basketProduct.HasOne(entity => entity.Basket)
                    .WithMany(basket => basket.BasketProducts)
                    .HasForeignKey(entity => entity.BasketId)
                    .OnDelete(DeleteBehavior.Cascade);
                    basketProduct.HasOne(entity => entity.Product)
                    .WithMany(product => product.BasketProducts)
                    .HasForeignKey(entity => entity.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                    

                    basketProduct.ToTable("BasketsProducts");
                });

            entityTypeBuilder
                .HasMany(product => product.Users)
                .WithMany(user => user.FavoriteProducts)
                .UsingEntity<UserFavoriteProduct>(UserFavoriteProduct =>
                {
                    UserFavoriteProduct.HasOne(entity => entity.Product)
                    .WithMany(product => product.UsersFavoriteProducts)
                    .HasForeignKey(entity => entity.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                    UserFavoriteProduct.HasOne(entity => entity.User)
                    .WithMany(user => user.UsersFavoriteProducts)
                    .HasForeignKey(entity => entity.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                    UserFavoriteProduct.HasKey(entity => new { entity.ProductId, entity.UserId });

                    UserFavoriteProduct.ToTable("UsersFavorites");
                });

            entityTypeBuilder.HasOne(entity => entity.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(entity => entity.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
