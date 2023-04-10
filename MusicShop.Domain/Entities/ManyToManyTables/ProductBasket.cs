using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities.ManyToManyTables
{
    public class ProductBasket
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public Guid BasketId { get; set; }
        public BasketEntity Basket { get; set; }
    }
}
