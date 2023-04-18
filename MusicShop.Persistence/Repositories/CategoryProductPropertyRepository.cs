using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Domain.Entities.ManyToManyTables;
using MusicShop.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories
{
    public class CategoryProductPropertyRepository:ICategoryProductPropertyRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryProductPropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAllByCategoryId(Guid categoryId)
        {
            var entities = _context.Set<CategoryProductProperty>().Where(e => e.CategoryId == categoryId);
            _context.Set<CategoryProductProperty>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
