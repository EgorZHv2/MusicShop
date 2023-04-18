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

        public async Task<Guid> Create(CreateProductPropertyDTO dto)
        {
            var entity = _mapper.Map<ProductPropertyEntity>(dto);

            var result = await _productPropertyRepository.Create(entity);
            if (dto.ValueType == Domain.Enums.PropertyValueType.Set && dto.Values.Any())
            {
             await _productPropertySetRepository.CreateMany(result, dto.Values); 
            }
            return result;
        }

        public async Task<List<OutputShortProductPropertyDTO>> GetShortList()
        {
            var entities = await _productPropertyRepository.GetAll();
            var result = _mapper.Map<List<OutputShortProductPropertyDTO>>(entities);
            return result;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _productPropertyRepository.GetById(id);
            if (entity != null)
                await _productPropertyRepository.Delete(entity);
        }

        public async Task<OutputProductPropertyDTO> GetById(Guid id)
        {
            var entity = await _productPropertyRepository.GetByIdWithSet(id);
            var result = _mapper.Map<OutputProductPropertyDTO>(entity);
            return result;
        }

        public async Task Update(UpdateProductPropertyDTO dto)
        {
            var existedEntity = await _productPropertyRepository.GetById(dto.Id);
            _mapper.Map(dto, existedEntity);
            
            if (dto.ValueType == Domain.Enums.PropertyValueType.Set && dto.Values.Any())
            {
              await  _productPropertySetRepository.DeleteAllByPropertyId(dto.Id);
              await _productPropertySetRepository.CreateMany(dto.Id, dto.Values); 
            }
            await _productPropertyRepository.Update(existedEntity);
        }

        public async Task<PageModelDTO<OutputProductPropertyDTO>> GetPage(PaginationDTO paginationDTO)
        {
            var pages = await _productPropertyRepository.GetPage(paginationDTO);
            var result = _mapper.Map<PageModelDTO<OutputProductPropertyDTO>>(pages);
            return result;
        }
    }
}
