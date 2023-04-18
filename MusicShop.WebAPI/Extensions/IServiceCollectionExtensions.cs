using Microsoft.Extensions.DependencyInjection;
using MusicShop.Application.Mappers;
using MusicShop.Persistance.Repositories;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Application.Services;

namespace MusicShop.WebAPI.Extensions
{ 
    public static class IServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
           

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ICategoryProductPropertyRepository, CategoryProductPropertyRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductBasketRepository, ProductBasketRepository>();
            services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
            services.AddScoped<IProductPropertySetRepository, ProductPropertySetRepository>();
            services.AddScoped<IProductPropertyValueRepository, ProductPropertyValueRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserFavoriteProductRepository, UserFavoriteProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddScoped<IProductPropertyService, ProductPropertyService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
