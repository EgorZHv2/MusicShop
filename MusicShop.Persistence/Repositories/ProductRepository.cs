using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Filters.Product;
using MusicShop.Domain.Enums;

namespace MusicShop.Persistance.Repositories
{
    public class ProductRepository:BaseEntityRepository<ProductEntity>,IProductRepository
    {
        private readonly IProductPropertyRepository _productPropertyRepository;
        public ProductRepository(ApplicationDbContext context,
            IProductPropertyRepository productPropertyRepository):base(context) 
        {
            _productPropertyRepository = productPropertyRepository;
        }
        public async Task<ProductEntity?> GetDetailedById(Guid id)
        {
            return await _dbset
                .Include(e => e.Category)
                .Include(e => e.ProductPropertiesValues)
                .ThenInclude(e =>  e.ProductPropertySetValue)
                .Include(e=>e.ProductPropertiesValues)
                .ThenInclude(e=>e.Property)
                .FirstOrDefaultAsync(e => e.Id == id);         
        }
        public  async Task<PageModelDTO<ProductEntity>> GetPage(ProductFilter filter, PaginationDTO pagination)
        {
            IQueryable<ProductEntity> queryable = _dbset
                .Include(e => e.Category)
                .Include(e=>e.ProductPropertiesValues)
                .Include(e=>e.ProductProperties);

            
            queryable = filter.MinPrice != null ? queryable.Where(e =>e.Price >= filter.MinPrice) : queryable;
            queryable = filter.MaxPrice != null ? queryable.Where(e =>e.Price <= filter.MaxPrice) : queryable;
            queryable = !string.IsNullOrEmpty(filter.SearchQuery) ? queryable = queryable.Where(e => e.Name.Contains(filter.SearchQuery)) : queryable; 
           

            var propertiesList = await _productPropertyRepository.GetManyByIds(filter.ProductPropertyValues.Select(e => e.PropertyId ).ToList());
            foreach (var item in filter.ProductPropertyValues)
            {
                var propertyType = propertiesList.FirstOrDefault(e=>e.Id == item.PropertyId).ValueType;
                switch (propertyType)
                {
                    case PropertyValueType.Text:
                        queryable = queryable.Where(e => e.ProductPropertiesValues.FirstOrDefault(e => e.PropertyId == item.PropertyId).TextValue == item.Value);
                        break;
                    case PropertyValueType.Numeric:
                        queryable =  queryable.Where(e => e.ProductPropertiesValues.FirstOrDefault(e => e.PropertyId == item.PropertyId).NumericValue == Convert.ToDouble(item.Value));
                        break;
                    case PropertyValueType.Bool:
                        queryable =  queryable.Where(e => e.ProductPropertiesValues.FirstOrDefault(e => e.PropertyId == item.PropertyId).BoolValue == Convert.ToBoolean(item.Value));
                        break;
                    case PropertyValueType.Set:
                        queryable =  queryable.Where(e => e.ProductPropertiesValues.FirstOrDefault(e => e.PropertyId == item.PropertyId).ValueFromSetId == new Guid(item.Value));
                        break;
                }    
            }
            var result = await ToPageModel(queryable, pagination);
           
            return result;
        }
      
    }
}
