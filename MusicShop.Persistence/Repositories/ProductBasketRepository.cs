using Microsoft.EntityFrameworkCore;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Domain.Entities.ManyToManyTables;
using MusicShop.Domain.Options;
using MusicShop.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories
{
    public class ProductBasketRepository:IProductBasketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserData _userData;
        public ProductBasketRepository
        (
            ApplicationDbContext context,
            UserData userData
        )
        {
            _context = context;
            _userData = userData;
        }
        public async Task RemoveProductFromBasket(Guid productId)
        {
           var entity = await _context.Set<ProductBasket>().FirstOrDefaultAsync(e=>e.BasketId == _userData.Id && e.ProductId == productId);
           _context.Set<ProductBasket>().Remove(entity);
           await _context.SaveChangesAsync();
        }
        public async Task ClearBasket()
        {
            var entities = _context.Set<ProductBasket>().Where(e => e.BasketId == _userData.Id);
            _context.Set<ProductBasket>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
