using MusicShop.Domain.Entities.ManyToManyTables;
using MusicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Domain.Entities
{
    public class UserEntity:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public UserRole Role { get; set; }
        public DateTime LastLogin { get; set; }
        public List<OrderEntity> Orders { get; set; }
        public List<ReviewEntity> Reviews { get; set; }

        public List<ProductEntity> FavoriteProducts { get; set; }
        public List<UserFavoriteProduct> UsersFavoriteProducts { get; set; }

        public BasketEntity Basket { get; set; }
    }
}
