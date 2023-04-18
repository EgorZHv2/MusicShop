using AutoMapper;
using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.ProductProperty;
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
        public async Task<Guid> Create(CreateCategoryDTO dto)
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
        public async Task Update(UpdateCategoryDTO dto)
        {
            var existedEntity = await _categoryRepository.GetById(dto.Id);
            _mapper.Map(dto, existedEntity);
            await _categoryProductProperty.DeleteAllByCategoryId(dto.Id);
            if (dto.PropertiesIds.Any())
            {
               
                var properties = await _productPropertyRepository.GetManyByIds(dto.PropertiesIds);
                existedEntity.ProductProperties.AddRange(properties);
            }
            await _categoryRepository.Update(existedEntity);
        }

        public async Task<List<OutputShortCategoryDTO>> GetShortList()
        {
            var entities = await _categoryRepository.GetAll();
            var result = _mapper.Map<List<OutputShortCategoryDTO>>(entities);
            return result;
        }
        public async Task<PageModelDTO<OutputCategoryDTO>> GetPage(PaginationDTO dto)
        {
            var entities = await _categoryRepository.GetPage(dto);
            var result = _mapper.Map<PageModelDTO<OutputCategoryDTO>>(entities);
            return result;
        }
        public async Task<OutputCategoryDTO> GetById(Guid id)
        {
            var entity = await _categoryRepository.GetByIdWithProperties(id);
            var result = _mapper.Map<OutputCategoryDTO>(entity);
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
