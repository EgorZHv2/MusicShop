using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories
{
    public class ReviewRepository:BaseEntityRepository<ReviewEntity>,IReviewRepository 
    {
        public ReviewRepository(ApplicationDbContext context): base(context) { }
    }
}
