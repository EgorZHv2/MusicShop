
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<UserEntity,IdentityRole<Guid>,Guid>
    {
        public AppIdentityDbContext()
        {
            
        }
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost;Port = 5432; Database = MusicShopIdentityDB; UserId = postgres; Password = 1385620;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(entity => entity.ToTable(name: "Users"));
            modelBuilder.Entity<IdentityRole<Guid>>(entity => entity.ToTable(name: "Roles"));
            modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
                entity.ToTable(name: "UserRoles"));
            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
                entity.ToTable(name: "UserClaim"));
            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
                entity.ToTable("UserLogins"));
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
                entity.ToTable("UserTokens"));
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
                entity.ToTable("RoleClaims"));
        }
    }
}
