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
    public class ProductPropertySetRepository:IProductPropertySetRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductPropertySetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateMany(Guid productId,List<string> values)
        {
            List<ProductPropertySetEntity> entites = new List<ProductPropertySetEntity>();
            
            
        }
    }
}
