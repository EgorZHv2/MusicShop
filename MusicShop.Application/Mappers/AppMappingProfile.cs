using AutoMapper;
using MusicShop.Application.DTO.Address;
using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.Identity;
using MusicShop.Application.DTO.Order;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.DTO.ProductPropertySet;
using MusicShop.Application.DTO.ProductPropertyValue;
using MusicShop.Application.DTO.Review;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            CreateMap<ProductEntity, ProductDetailedOutputDTO>()
                .ForMember(e => e.CategoryName, opt => opt.MapFrom(e => e.Category.Name))
                .ForMember(e => e.Properties, opt => opt
                    .MapFrom(e => e.ProductPropertiesValues
                        .Select(e => new ProductPropertyValuetListOutputDTO
                        {
                            PropertyName = e.Property.Name,
                            PropertyValue = GetPropertyValue(e)
                        
                        })));
            CreateMap<ProductEntity, ProductOutputDTO>()
                .ForMember(e=>e.CategoryName,opt => opt.MapFrom(e=>e.Category.Name));
            CreateMap<PageModelDTO<ProductEntity>,PageModelDTO<ProductOutputDTO>>();

            //User maps
            CreateMap<RegisterDTO, UserEntity>();

            //Review maps
            CreateMap<ReviewCreateDTO, ReviewEntity>();
            CreateMap<ReviewUpdateDTO, ReviewEntity>();
            CreateMap<ReviewEntity, ReviewOutputDTO>();
            CreateMap<ReviewEntity,ReviewListOutputDTO>();
            CreateMap<PageModelDTO<ReviewEntity>, PageModelDTO<ReviewListOutputDTO>>();

            //Address maps
            CreateMap<AddressCreateDTO, AddressEntity>();
            CreateMap<AddressEntity, AddressOutputDTO>();

            //Order maps
            CreateMap<OrderCreateDTO, OrderEntity>();
            CreateMap<OrderUpdateDTO, OrderEntity>();
            CreateMap<OrderEntity, OrderOutputDTO>()
                .ForMember(e => e.ProductName, opt => opt.MapFrom(e => e.Product.Name))
                .ForMember(e => e.ProductPrice, opt => opt.MapFrom(e => e.Product.Price));
            CreateMap<PageModelDTO<OrderEntity>, PageModelDTO<OrderOutputDTO>>();
            CreateMap<OrderEntity, OrderDetailedOutputDTO>()
                .ForMember(e => e.ProductName, opt => opt.MapFrom(e => e.Product.Name))
                .ForMember(e => e.ProductPrice, opt => opt.MapFrom(e => e.Product.Price))
                .ForMember(e => e.Country, opt => opt.MapFrom(e => e.Address.Country))
                .ForMember(e => e.Region, opt => opt.MapFrom(e => e.Address.Region))
                .ForMember(e => e.City, opt => opt.MapFrom(e => e.Address.City))
                .ForMember(e => e.Place, opt => opt.MapFrom(e => e.Address.Place))
                .ForMember(e => e.Index, opt => opt.MapFrom(e => e.Address.Index));

        }
        private string GetPropertyValue(ProductPropertyValueEntity entity)
        {
            switch (entity.Property.ValueType)
            {
                case PropertyValueType.Text: return entity.TextValue;
                case PropertyValueType.Numeric: return entity.NumericValue.ToString();
                case PropertyValueType.Bool: return entity.BoolValue.ToString();
                case PropertyValueType.Set: return entity.ProductPropertySetValue.Value;
                default: return string.Empty;
            }
        }

    }
}
