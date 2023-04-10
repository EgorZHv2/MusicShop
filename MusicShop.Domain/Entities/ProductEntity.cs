using MusicShop.Domain.Entities.ManyToManyTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class ProductEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int   QuantityInStock { get; set; }
        public double? Discount { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid? CategoryId { get; set; }
        public List<ProductPropertyEntity> ProductProperties { get; set;}
        public List<ProductPropertyValueEntity> ProductPropertiesValues { get; set; }

        public List<OrderEntity> Orders { get; set; }
        public List<BasketEntity> Baskets { get; set; }
        public List<ProductBasket> BasketProducts { get; set; }
        public List<UserEntity> Users { get; set; }
        public List<UserFavoriteProduct> UsersFavoriteProducts { get; set; }
    }
}
