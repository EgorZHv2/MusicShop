using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories.Interfaces
{
    public interface IBaseEntityRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetById(Guid Id);

        IEnumerable<TEntity> GetManyByIds(ICollection<Guid> ids);
       
        Task<Guid> Create(TEntity entity);

        Task CreateMany(ICollection<TEntity> entities);

        Task Update(TEntity entity);

        Task UpdateMany(ICollection<TEntity> entities);

        Task Delete(TEntity entity);

        Task DeleteMany(ICollection<TEntity> entities);

        Task HardDelete(TEntity entity);
        Task HardDeleteMany(ICollection<TEntity> entities);
    }
}
