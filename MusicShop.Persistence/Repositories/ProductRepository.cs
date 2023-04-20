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

namespace MusicShop.Persistance.Repositories
{
    public class ProductRepository:BaseEntityRepository<ProductEntity>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context):base(context) { }
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
        public override async Task<PageModelDTO<ProductEntity>> GetPage(PaginationDTO pagination)
        {
            var queryable = _dbset.Include(e => e.Category);
            var result = await ToPageModel(queryable, pagination);
            return result;
        }
    }
}
