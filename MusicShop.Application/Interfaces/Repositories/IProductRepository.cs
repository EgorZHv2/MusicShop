using MusicShop.Application.DTO.Filters.Product;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IProductRepository : IBaseEntityRepository<ProductEntity>
    {
        Task<ProductEntity?> GetDetailedById(Guid id);
        Task<PageModelDTO<ProductEntity>> GetPage(ProductFilter filter, PaginationDTO pagination);
    }
}