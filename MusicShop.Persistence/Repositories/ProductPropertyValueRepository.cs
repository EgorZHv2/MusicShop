using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Persistance.Contexts;

namespace MusicShop.Persistance.Repositories
{
    public class ProductPropertyValueRepository:IProductPropertyValueRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductPropertyValueRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAllByProductId(Guid id)
        {
            var entities = _context.ProductsPropertiesValues.Where(e => e.ProductId == id);
            _context.ProductsPropertiesValues.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
