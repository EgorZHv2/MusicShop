using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Domain.Entities;

namespace MusicShop.Persistance.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<BaseEntity> BaseEntities { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
          
        }
        public ApplicationDbContext()
        {
          
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost;Port = 5432; Database = MusicShopDB; UserId = postgres; Password = 1385620;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
        }
    }
}
