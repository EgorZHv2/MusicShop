using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Application.DTO.PageModels;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.Persistance.Repositories
{
    public class OrderRepository:BaseEntityRepository<OrderEntity>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context):base(context) { }
        public override async Task<PageModelDTO<OrderEntity>> GetPage(PaginationDTO pagination)
        {
            var queryable = _dbset.Include(e => e.Product);
            var pages = await ToPageModel(queryable,pagination);
            return pages;
        }
        public override async Task<OrderEntity?> GetById(Guid Id)
        {
            var result = await _dbset.Include(e => e.Product).Include(e => e.Address).FirstOrDefaultAsync(e=>e.Id == Id);
            return result;
        }
    }
}
