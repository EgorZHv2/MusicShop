using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicShop.Application.Exceptions;

namespace MusicShop.Persistance.Repositories
{
    public class AddressRepository:BaseEntityRepository<AddressEntity>,IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context) { }
        public async Task<AddressEntity?> GetLastAddressByUserId(Guid userId)
        {
            var userorder = await _context.Orders.Include(e=>e.Address).OrderByDescending(e=>e.CreatedAt).FirstOrDefaultAsync(e=>e.UserId== userId);
            if(userorder == null)
            {
                throw new OrderNotFoundException();
            }
          
            return userorder.Address;
        }
    }
}
