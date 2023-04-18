using AutoMapper;
using MusicShop.Application.DTO.Product;
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
        public async Task<Guid> Create(CreateProductDTO dto)
        {
            var entity = _mapper.Map<ProductEntity>(dto);
            var result = await _productRepository.Create(entity);
            return result;
        }
        public async Task Update(UpdateProductDTO dto)
        {
            var existedEntity = await _productRepository.GetById(dto.Id);
            _mapper.Map(dto, existedEntity);
            await _productPropertyValues.DeleteAllByProductId(existedEntity.Id);
            await _productRepository.Update(existedEntity);
        }
        public async Task<OutputProductDTO> GetById(Guid id)
        {
            var entity = await _productRepository.GetById(id);
            var result = _mapper.Map<OutputProductDTO>(entity);
            return result;
        }
    }
}
