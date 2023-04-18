using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseEntityRepository<CategoryEntity>
    {
        Task<List<CategoryEntity>> GetAll();
        Task<CategoryEntity?> GetByIdWithProperties(Guid Id);
    }
}