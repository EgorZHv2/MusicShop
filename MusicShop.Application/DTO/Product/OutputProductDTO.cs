using MusicShop.Domain.Entities.ManyToManyTables;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.DTO.Product
{
    public class OutputProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public double? Discount { get; set; }
        public Guid CategoryId { get; set; }
        public List<ProductPropertyEntity> ProductProperties { get; set;}
        public List<ProductPropertyValueEntity> ProductPropertiesValues { get; set; }

        public List<OrderEntity> Orders { get; set; }
        public List<BasketEntity> Baskets { get; set; }
        public List<ProductBasket> BasketProducts { get; set; }
        public List<UserEntity> Users { get; set; }
        public List<UserFavoriteProduct> UsersFavoriteProducts { get; set; }
    }
}
