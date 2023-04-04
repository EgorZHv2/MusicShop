using MusicShop.Domain.Entities.ManyToManyTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class BasketEntity
    {
        public List<ProductEntity> Products { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
