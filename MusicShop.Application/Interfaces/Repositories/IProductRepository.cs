using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IProductRepository : IBaseEntityRepository<ProductEntity>
    {
        Task<ProductEntity?> GetDetailedById(Guid id);
    }
}