using AutoMapper;
using MusicShop.Application.DTO.Filters.Product;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Exceptions;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductPropertyValueRepository _productPropertyValues;
        private readonly IMapper _mapper;
        public ProductService
        (
            IProductRepository productRepository,
            IMapper mapper,
            IProductPropertyValueRepository productPropertyValues
        ) 
        {
            _productRepository= productRepository;
            _mapper= mapper;
            _productPropertyValues = productPropertyValues;
        }
        public async Task<Guid> Create(ProductCreateDTO dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);
            var result = await _productRepository.Create(entity);
            return result;
        }
        public async Task Update(ProductUpdateDTO dto)
        {
            var existingEntity = await _productRepository.GetById(dto.Id);
            if(existingEntity == null) 
            {
                throw new ProductNotFoundException();
            }
            _mapper.Map(dto, existingEntity);
            await _productPropertyValues.DeleteAllByProductId(existingEntity.Id);
            await _productRepository.Update(existingEntity);
        }
        public async Task<ProductDetailedOutputDTO> GetById(Guid id)
        {
            var entity = await _productRepository.GetDetailedById(id);
            if(entity == null) 
            {
                throw new ProductNotFoundException();
            }
            var result = _mapper.Map<ProductDetailedOutputDTO>(entity);
            return result;
        }
        public async Task<PageModelDTO<ProductOutputDTO>> GetPage(ProductFilter filter, PaginationDTO dto)
        {
            var pages = await _productRepository.GetPage(filter,dto);
            var result = _mapper.Map<PageModelDTO<ProductOutputDTO>>(pages);
            return result;
        }
        public async Task Delete(Guid id)
        {
            var entity = await _productRepository.GetById(id);
            if (entity != null)
               await _productRepository.Delete(entity);
        }
            
        
    }
}
