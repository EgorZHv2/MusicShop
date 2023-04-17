using AutoMapper;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.DTO.ProductPropertySet;
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
            //ProductProperty mappings
            CreateMap<CreateProductPropertyDTO, ProductPropertyEntity>();
            CreateMap<UpdateProductPropertyDTO, ProductPropertyEntity>();
            CreateMap<ProductPropertyEntity, OutputProductPropertyDTO>();
            CreateMap<ProductPropertySetEntity, OutputProductPropertySetDTO>();
            CreateMap<PageModelDTO<ProductPropertyEntity>, PageModelDTO<OutputProductPropertyDTO>>();
            CreateMap<ProductPropertyEntity, OutputShortProductPropertyDTO>();



        }

    }
}
