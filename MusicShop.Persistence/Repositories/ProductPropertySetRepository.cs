using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories
{
    public class ProductPropertySetRepository : IProductPropertySetRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPropertySetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateMany(Guid propertyId, List<string> values)
        {
            List<ProductPropertySetEntity> entites = new List<ProductPropertySetEntity>();
            foreach (var value in values)
            {
                entites.Add(
                    new ProductPropertySetEntity
                    {
                        Id = Guid.NewGuid(),
                        ProductPropertyId = propertyId,
                        Value = value
                    }
                );
            }
            await _context.ProductPropertiesSets.AddRangeAsync(entites);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAllByPropertyId(Guid propertyId)
        {
            var entities = _context.ProductPropertiesSets.Where(e => e.ProductPropertyId == propertyId);
            _context.ProductPropertiesSets.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
