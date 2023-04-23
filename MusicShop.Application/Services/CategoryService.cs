using AutoMapper;
using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.ProductProperty;
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
    public class CategoryService:ICategoryService
    {
        private readonly IProductPropertyRepository _productPropertyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryProductPropertyRepository _categoryProductProperty;
        private readonly IMapper _mapper;
        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IProductPropertyRepository productPropertyRepository,
            ICategoryProductPropertyRepository categoryProductProperty
            ) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _productPropertyRepository = productPropertyRepository;
            _categoryProductProperty = categoryProductProperty;
        }
        public async Task<Guid> Create(CategoryCreateDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _categoryRepository.Create(entity);
            if(dto.PropertiesIds.Any())
            {
                var properties = await _productPropertyRepository.GetManyByIds(dto.PropertiesIds);
                entity.ProductProperties.AddRange(properties);
                await  _categoryRepository.Update(entity);
            }
            return result;
        }
        public async Task Update(CategoryUpdateDTO dto)
        {
            var existingEntity = await _categoryRepository.GetById(dto.Id);
            if(existingEntity == null)
            {
                throw new CategoryNotFoundException();
            }
            _mapper.Map(dto, existingEntity);
            await _categoryProductProperty.DeleteAllByCategoryId(dto.Id);
            if (dto.PropertiesIds.Any())
            {
               
                var properties = await _productPropertyRepository.GetManyByIds(dto.PropertiesIds);
                existingEntity.ProductProperties.AddRange(properties);
            }
            await _categoryRepository.Update(existingEntity);
        }

        public async Task<List<CategoryShortOutputDTO>> GetShortList()
        {
            var entities = await _categoryRepository.GetAll();
            var result = _mapper.Map<List<CategoryShortOutputDTO>>(entities);
            return result;
        }
        public async Task<PageModelDTO<CategoryOutputDTO>> GetPage(PaginationDTO dto)
        {
            var entities = await _categoryRepository.GetPage(dto);
            var result = _mapper.Map<PageModelDTO<CategoryOutputDTO>>(entities);
            return result;
        }
        public async Task<CategoryOutputDTO> GetById(Guid id)
        {
            var entity = await _categoryRepository.GetByIdWithProperties(id);
            if(entity == null)
            {
                throw new CategoryNotFoundException();
            }
            var result = _mapper.Map<CategoryOutputDTO>(entity);
            return result;
        }
        public async Task Delete(Guid id)
        {
            var entity = await _categoryRepository.GetById(id);
            if (entity != null)
               await _categoryRepository.Delete(entity);
        }

    }
}
