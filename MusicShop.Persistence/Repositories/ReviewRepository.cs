using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Application.DTO.PageModels;

namespace MusicShop.Persistance.Repositories
{
    public class ReviewRepository:BaseEntityRepository<ReviewEntity>,IReviewRepository 
    {
        public ReviewRepository(ApplicationDbContext context): base(context) { }

        public async Task<PageModelDTO<ReviewEntity>> GetPageByUserId(Guid userId,PaginationDTO pagination)
        {
            var queryable = _dbset.Where(e => e.UserId == userId);
            var pages = await ToPageModel(queryable, pagination);
            return pages;
        }
        public async Task<PageModelDTO<ReviewEntity>> GetPageByProductId(Guid productId,PaginationDTO pagination)
        {
             var queryable = _dbset.Where(e => e.ProductId == productId);
            var pages = await ToPageModel(queryable, pagination);
            return pages;
        }
    }
}
