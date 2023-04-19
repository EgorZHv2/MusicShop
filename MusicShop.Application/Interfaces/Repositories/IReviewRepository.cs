using MusicShop.Application.DTO.PageModels;
using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IReviewRepository : IBaseEntityRepository<ReviewEntity>
    {
        Task<PageModelDTO<ReviewEntity>> GetPageByUserId(Guid userId, PaginationDTO pagination);
        Task<PageModelDTO<ReviewEntity>> GetPageByProductId(Guid productId, PaginationDTO pagination);
    }
}