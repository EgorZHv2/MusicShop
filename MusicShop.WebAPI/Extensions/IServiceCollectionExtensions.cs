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
using MusicShop.Infrastructure.Services;
using MusicShop.Domain.Options;
using MusicShop.Domain.Options.Configurations;

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
            services.AddScoped<IFileInfoRepository, FileInfoRepository>();
            
            
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddScoped<IProductPropertyService, ProductPropertyService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IReviewService,ReviewService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFileService, FileService>();
        }

        public static void AddAppOptions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<UserData>();
            services.Configure<JwtTokenConfiguration>(configuration.GetSection("JwtTokenConfiguration"));
        }
    }
}
