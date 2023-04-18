using MusicShop.Application.DTO.PageModels;
using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IBaseEntityRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetById(Guid Id);
        Task<PageModelDTO<TEntity>> GetPage(PaginationDTO pagination);
        Task<IEnumerable<TEntity>> GetManyByIds(ICollection<Guid> ids);

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