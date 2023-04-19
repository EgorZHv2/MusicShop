using AutoMapper;
using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.Identity;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.DTO.ProductPropertySet;
using MusicShop.Application.DTO.ProductPropertyValue;
using MusicShop.Application.DTO.Review;
using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Mappers
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile() 
        {
            //ProductProperty maps
            CreateMap<ProductPropertyCreateDTO, ProductPropertyEntity>();
            CreateMap<ProductPropertyUpdateDTO, ProductPropertyEntity>();
            CreateMap<ProductPropertyEntity, ProductPropertyOutputDTO>();
            CreateMap<ProductPropertySetEntity, ProductPropertySetOutputDTO>();
            CreateMap<PageModelDTO<ProductPropertyEntity>, PageModelDTO<ProductPropertyOutputDTO>>();
            CreateMap<ProductPropertyEntity, ProductPropertyShortOutputDTO>();

            //Category maps
            CreateMap<CategoryCreateDTO, CategoryEntity>();
            CreateMap<CategoryUpdateDTO, CategoryEntity>();
            CreateMap<CategoryEntity,CategoryOutputDTO>();
            CreateMap<CategoryEntity, CategoryShortOutputDTO>();
            CreateMap<PageModelDTO<CategoryEntity>,PageModelDTO<CategoryOutputDTO>>();

            //Product maps
            CreateMap<ProductPropertyValueDTO,ProductPropertyValueEntity>().ReverseMap();
            CreateMap<ProductCreateDTO, ProductEntity>();
            CreateMap<ProductUpdateDTO, ProductEntity>();

            //User maps
            CreateMap<RegisterDTO, UserEntity>();

            //Review maps
            CreateMap<ReviewCreateDTO, ReviewEntity>();
            CreateMap<ReviewUpdateDTO, ReviewEntity>();
            CreateMap<ReviewEntity, ReviewOutputDTO>();
            CreateMap<ReviewEntity,ReviewListOutputDTO>();
            CreateMap<PageModelDTO<ReviewEntity>, PageModelDTO<ReviewListOutputDTO>>();
         
        }

    }
}
