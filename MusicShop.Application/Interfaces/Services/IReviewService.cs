using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Review;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IReviewService
    {
        Task<Guid> Create(ReviewCreateDTO dto);
        Task Update(ReviewUpdateDTO dto);
        Task<ReviewOutputDTO> GetById(Guid id);
        Task<PageModelDTO<ReviewListOutputDTO>> GetPageByProductId(Guid productId, PaginationDTO pagination);
        Task<PageModelDTO<ReviewListOutputDTO>> GetPageByUserId(PaginationDTO pagination);
        Task Delete(Guid id);
        
    }
}
