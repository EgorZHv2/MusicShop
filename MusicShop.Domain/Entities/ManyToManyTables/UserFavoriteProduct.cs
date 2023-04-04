using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities.ManyToManyTables
{
    public class UserFavoriteProduct
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
