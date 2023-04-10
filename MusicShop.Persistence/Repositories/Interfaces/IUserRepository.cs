using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories.Interfaces
{
    public interface IUserRepository:IBaseEntityRepository<UserEntity>
    {
    }
}
