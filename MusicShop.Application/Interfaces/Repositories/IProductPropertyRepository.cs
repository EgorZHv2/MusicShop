using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IProductPropertyRepository : IBaseEntityRepository<ProductPropertyEntity>
    {
        Task<List<ProductPropertyEntity>> GetAll();
    }
}