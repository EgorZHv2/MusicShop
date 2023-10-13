using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Domain.Entities;
using MusicShop.Persistance.Configurations;
using System.Reflection.Emit;

namespace MusicShop.Persistance.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<ProductPropertyEntity> ProductsProperties { get; set; } = null!;
        public DbSet<ProductPropertyValueEntity> ProductsPropertiesValues { get; set; }= null!;
        public DbSet<UserEntity> Users { get; set; }= null!;
        public DbSet<CategoryEntity> Categories { get; set; }= null!;
        public DbSet<BasketEntity> Baskets { get; set; } = null!;
        public DbSet<OrderEntity> Orders { get; set; }= null!;
        public DbSet<AddressEntity> Addresses { get; set; }= null!;
        public DbSet<ProductPropertySetEntity> ProductPropertiesSets { get; set; }= null!;
        public DbSet<ReviewEntity> Reviews { get; set; }= null!;
        public DbSet<FileInfoEntity> FileInfos { get; set; }= null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
          
        }
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost;Port = 5432; Database = MusicShopDB; UserId = postgres; Password = 1385620;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          
             builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new BasketConfiguration());
             builder.ApplyConfiguration(new CategoryConfuguration());
             builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductConfuguration());
            builder.ApplyConfiguration(new ProductPropertyConfuguration());
            builder.ApplyConfiguration(new ProductPropertySetConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
             
        }
    }
}
