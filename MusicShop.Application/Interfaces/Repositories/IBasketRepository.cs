using MusicShop.Application.DTO.PageModels;
using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{ 
    public interface IBasketRepository
    {
         Task Create(BasketEntity entity);
         Task Delete(BasketEntity entity);
        Task<BasketEntity> GetBasketByUserId(Guid userId);
        Task Update(BasketEntity entity);
       Task<PageModelDTO<ProductEntity>> GetProductsPageByUserId(PaginationDTO dto);
    }
}