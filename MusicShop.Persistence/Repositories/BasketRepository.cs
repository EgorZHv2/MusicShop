using Microsoft.EntityFrameworkCore;
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
    public class BasketRepository:IBasketRepository
    {
        private readonly ApplicationDbContext _context;
        public BasketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BasketEntity>> GetProductsInUserBasket(Guid userId)
        {
            return await _context.Baskets.Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task Create(BasketEntity entity)
        {
           await  _context.Baskets.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(BasketEntity entity)
        {
             _context.Baskets.Remove(entity);
            await _context.SaveChangesAsync();
        }
        
    }
}
