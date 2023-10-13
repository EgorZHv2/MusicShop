using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Domain.Options;

namespace MusicShop.Persistance.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserData _userData;
        public BasketRepository(ApplicationDbContext context,UserData userData)
        {
            _context = context;
            _userData = userData;
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
        public async Task<BasketEntity?> GetBasketByUserId(Guid userId)
        {
            return await _context.Baskets.Include(e=>e.Products).FirstOrDefaultAsync(e=>e.UserId == userId);
        }
        public async Task Update(BasketEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        
        }
        
        public async Task<PageModelDTO<ProductEntity>> GetProductsPageByUserId(PaginationDTO dto)
        {
            var basket = await  _context.Baskets.Include(e => e.Products).FirstOrDefaultAsync(e => e.UserId == _userData.Id);
            var pages =   new PageModelDTO<ProductEntity>
            {
                Values =  basket.Products.Skip((dto.PageNumber - 1) * dto.PageSize).Take(dto.PageSize),
                ItemsOnPage = dto.PageSize,
                CurrentPage = dto.PageNumber,
                TotalItems = basket.Products.Count(),
                TotalPages = (int)Math.Ceiling(basket.Products.Count() / (double)dto.PageSize)
            };
            return pages;
        }
       
        
        
    }
}
