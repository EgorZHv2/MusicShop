using AutoMapper;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Domain.Entities;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Application.Exceptions;

namespace MusicShop.Application.Services
{
    public class ProductPropertyService : IProductPropertyService
    {
        private readonly IProductPropertyRepository _productPropertyRepository;
        private readonly IProductPropertySetRepository _productPropertySetRepository;
        private readonly IMapper _mapper;

        public ProductPropertyService(
            IProductPropertyRepository productPropertyRepository,
            IMapper mapper,
            IProductPropertySetRepository productPropertySetRepository
        )
        {
            _productPropertyRepository = productPropertyRepository;
            _mapper = mapper;
            _productPropertySetRepository = productPropertySetRepository;
        }

        public async Task<Guid> Create(ProductPropertyCreateDTO dto)
        {
            var entity = _mapper.Map<ProductPropertyEntity>(dto);

            var result = await _productPropertyRepository.Create(entity);
            if (dto.ValueType == Domain.Enums.PropertyValueType.Set && dto.Values.Any())
            {
             await _productPropertySetRepository.CreateMany(result, dto.Values); 
            }
            return result;
        }

        public async Task<List<ProductPropertyShortOutputDTO>> GetShortList()
        {
            var entities = await _productPropertyRepository.GetAll();
            var result = _mapper.Map<List<ProductPropertyShortOutputDTO>>(entities);
            return result;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _productPropertyRepository.GetById(id);
            if (entity != null)
                await _productPropertyRepository.Delete(entity);
        }

        public async Task<ProductPropertyOutputDTO> GetById(Guid id)
        {
            var entity = await _productPropertyRepository.GetByIdWithSet(id);
            if(entity == null)
            {
                throw new ProductPropertyNotFoundException();
            }
            var result = _mapper.Map<ProductPropertyOutputDTO>(entity);
            return result;
        }

        public async Task Update(ProductPropertyUpdateDTO dto)
        {
            var existingEntity = await _productPropertyRepository.GetById(dto.Id);
            if(existingEntity == null)
            {
                throw new ProductPropertyNotFoundException();
            }
            _mapper.Map(dto, existingEntity);
            await  _productPropertySetRepository.DeleteAllByPropertyId(dto.Id);
            if (dto.ValueType == Domain.Enums.PropertyValueType.Set && dto.Values.Any())
            {
              await _productPropertySetRepository.CreateMany(dto.Id, dto.Values); 
            }
            await _productPropertyRepository.Update(existingEntity);
        }

        public async Task<PageModelDTO<ProductPropertyOutputDTO>> GetPage(PaginationDTO paginationDTO)
        {
            var pages = await _productPropertyRepository.GetPage(paginationDTO);
            var result = _mapper.Map<PageModelDTO<ProductPropertyOutputDTO>>(pages);
            return result;
        }
        public async Task<List<ProductPropertyOutputDTO>> GetProptiesByCategoryId(Guid id)
        {

            var entities = await _productPropertyRepository.GetPropertiesByCategoryId(id);
            var result = _mapper.Map<List<ProductPropertyOutputDTO>>(entities);
            return result;
        }
    }
}
