using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.Persistance.Repositories
{
    public class AddressRepository:BaseEntityRepository<AddressEntity>,IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context) { }
        public async Task<AddressEntity?> GetLastAddressByUserId(Guid userId)
        {
            var order = await _context.Orders.Include(e => e.Address).Where(e => e.UserId == userId).OrderByDescending(e=>e.Address.CreatedAt).FirstAsync();
            return order.Address;
        }
    }
}
