using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Application.DTO.PageModels;

namespace MusicShop.Persistance.Repositories
{
    public class ProductPropertyRepository:BaseEntityRepository<ProductPropertyEntity>, IProductPropertyRepository
    {
       public ProductPropertyRepository(ApplicationDbContext context) : base(context) { }

       public async Task<List<ProductPropertyEntity>> GetAll() 
       {
            return await _dbset.ToListAsync();
       }
       public override async Task<PageModelDTO<ProductPropertyEntity>> GetPage(PaginationDTO pagination)
       {
            var values = _dbset.Include(e => e.ProductPropertySet);
            var result = await ToPageModel(values, pagination);
            return result;
       }
       public  async Task<ProductPropertyEntity?> GetByIdWithSet(Guid Id)
       {
            return await _dbset.Include(e=>e.ProductPropertySet).FirstOrDefaultAsync(e=>e.Id == Id);
       }
       public async Task<List<ProductPropertyEntity>> GetPropertiesByCategoryId(Guid id)
       {
            var category = await _context.Categories.Include(e=>e.ProductProperties).ThenInclude(e=>e.ProductPropertySet).FirstOrDefaultAsync(e => e.Id == id);
            return  category.ProductProperties;
       }

    }
}
