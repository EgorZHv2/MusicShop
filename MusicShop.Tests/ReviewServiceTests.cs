using AutoMapper;
using Moq;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Review;
using MusicShop.Application.Interfaces.Repositories;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicShop.Tests
{
    public class ReviewServiceTests
    {
        private readonly IMapper _mapper;
        private readonly UserData _userData = new UserData { Id = Guid.NewGuid() }; 
        public ReviewServiceTests() 
        {
            var myProfile = new AppMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
        [Fact]
        public async Task CreateTest()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.Create(It.IsAny<ReviewEntity>())).ReturnsAsync(Guid.NewGuid());
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
            var result = await service.Create(new ReviewCreateDTO { ProductId = Guid.NewGuid(), ProductScore = ProductScore.Five, ReviewText = "10 из 10 на кончиках пальцев" });
            Assert.IsType<Guid>(result);
        }
         [Fact]
        public async Task UpdateTest()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(new ReviewEntity());
            reviewRepository.Setup(e => e.Update(It.IsAny<ReviewEntity>()));
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
            var result = service.Update(new ReviewUpdateDTO { ProductScore = ProductScore.Five, ReviewText = "10 из 10 на кончиках пальцев",Id = Guid.NewGuid() });
            Assert.True(result.IsCompleted);
        }

         [Fact]
        public async Task UpdateNotFoundExceptionTest()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(()=>null);
            reviewRepository.Setup(e => e.Update(It.IsAny<ReviewEntity>()));
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
           
            await Assert.ThrowsAsync<ReviewNotFoundException>(async ()=> await service.Update(new ReviewUpdateDTO { ProductScore = ProductScore.Five, ReviewText = "10 из 10 на кончиках пальцев",Id = Guid.NewGuid() }));
        }
         [Fact]
        public async Task GetByIdTest()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(new ReviewEntity());
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
            var result = await service.GetById(Guid.NewGuid());
            Assert.IsType<ReviewOutputDTO>(result);
        }
        [Fact]
        public async Task GetByIdNotFoundExceptionTest()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(() => null);
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
            await Assert.ThrowsAsync<ReviewNotFoundException>(async ()=> await service.GetById(Guid.NewGuid()));
        }
        [Fact]
        public async Task GetPageByUserIdTest()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.GetPageByUserId(It.IsAny<Guid>(),It.IsAny<PaginationDTO>())).ReturnsAsync(new PageModelDTO<ReviewEntity>());
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
            var result = await service.GetPageByUserId(new PaginationDTO { PageNumber = 1, PageSize = 5});
            Assert.IsType<PageModelDTO<ReviewListOutputDTO>>(result);
        }
        [Fact]
        public async Task GetPageByProductIdTest()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.GetPageByProductId(It.IsAny<Guid>(),It.IsAny<PaginationDTO>())).ReturnsAsync(new PageModelDTO<ReviewEntity>());
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
            var result = await service.GetPageByProductId(Guid.NewGuid(),new PaginationDTO { PageNumber = 1, PageSize = 5});
            Assert.IsType<PageModelDTO<ReviewListOutputDTO>>(result);
        }
        [Fact]
        public void Delete()
        {
            var reviewRepository = new Mock<IReviewRepository>();
            reviewRepository.Setup(e => e.Delete(It.IsAny<ReviewEntity>()));
            var service = new ReviewService(reviewRepository.Object, _mapper, _userData);
            var result = service.Delete(Guid.NewGuid());
            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
