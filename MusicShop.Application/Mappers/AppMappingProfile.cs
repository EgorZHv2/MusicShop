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


            CreateMap<CreateProductPropertyDTO, ProductPropertyEntity>();


            CreateMap<ProductPropertyEntity, OutputPageProductPropertyDTO>();


            CreateMap<ProductPropertySetEntity, OutputProductPropertySetDTO>();


            CreateMap<PageModelDTO<ProductPropertyEntity>, PageModelDTO<OutputPageProductPropertyDTO>>();


            CreateMap<ProductPropertyEntity, OutputShortProductPropertyDTO>();

        }

    }
}
