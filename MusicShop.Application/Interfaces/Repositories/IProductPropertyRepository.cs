using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IProductPropertyRepository : IBaseEntityRepository<ProductPropertyEntity>
    {
        Task<List<ProductPropertyEntity>> GetAll();
        Task<ProductPropertyEntity?> GetByIdWithSet(Guid Id);
    }
}