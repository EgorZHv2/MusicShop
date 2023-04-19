using AutoMapper;
using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.Identity;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.DTO.ProductPropertySet;
using MusicShop.Application.DTO.ProductPropertyValue;
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
            CreateMap<CreateProductPropertyDTO, ProductPropertyEntity>();
            CreateMap<UpdateProductPropertyDTO, ProductPropertyEntity>();
            CreateMap<ProductPropertyEntity, OutputProductPropertyDTO>();
            CreateMap<ProductPropertySetEntity, OutputProductPropertySetDTO>();
            CreateMap<PageModelDTO<ProductPropertyEntity>, PageModelDTO<OutputProductPropertyDTO>>();
            CreateMap<ProductPropertyEntity, OutputShortProductPropertyDTO>();

            //Category maps
            CreateMap<CreateCategoryDTO, CategoryEntity>();
            CreateMap<UpdateCategoryDTO, CategoryEntity>();
            CreateMap<CategoryEntity,OutputCategoryDTO>();
            CreateMap<CategoryEntity, OutputShortCategoryDTO>();
            CreateMap<PageModelDTO<CategoryEntity>,PageModelDTO<OutputCategoryDTO>>();

            //Product maps
            CreateMap<ProductPropertyValueDTO,ProductPropertyValueEntity>().ReverseMap();
            CreateMap<CreateProductDTO, ProductEntity>();
            CreateMap<UpdateProductDTO, ProductEntity>();

            //User maps
            CreateMap<RegisterDTO, UserEntity>();
         
        }

    }
}
