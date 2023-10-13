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
    public class CategoryRepository:BaseEntityRepository<CategoryEntity>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<CategoryEntity>> GetAll()
        {
            return await _dbset.ToListAsync();
        }
        public override async Task<PageModelDTO<CategoryEntity>> GetPage(PaginationDTO pagination)
        {
            var values = _dbset.Include(e => e.ProductProperties);
            var result = await ToPageModel(values, pagination);
            return result;
        }
        public  async Task<CategoryEntity?> GetByIdWithProperties(Guid Id)
        {
            return await _dbset.Include(e=>e.ProductProperties).FirstOrDefaultAsync(e=>e.Id == Id);
        }
    }
}
