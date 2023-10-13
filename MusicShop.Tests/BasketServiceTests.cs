using AutoMapper;
using Moq;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Tests
{
    public class BasketServiceTests
    {
        private readonly IMapper _mapper;
        private readonly UserData _userData = new UserData { Id = Guid.NewGuid() }; 
        public BasketServiceTests() 
        { 
             var myProfile = new AppMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task AddProductToBasketNotFoundExceptionTest()
        {
            var basketRepository = new Mock<IBasketRepository>();
            var productRepository = new Mock<IProductRepository>();
            var productBasketRepository = new Mock<IProductBasketRepository>();
            basketRepository.Setup(e => e.GetBasketByUserId(It.IsAny<Guid>())).ReturnsAsync(new BasketEntity());
            productRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(()=> null);
            basketRepository.Setup(e => e.Update(It.IsAny<BasketEntity>()));

            var service = new BasketService(basketRepository.Object, productBasketRepository.Object, productRepository.Object, _userData, _mapper);
            await Assert.ThrowsAsync<ProductNotFoundException>(async () => await service.AddProductToBasket(Guid.NewGuid()));
        }
        [Fact]
        public async Task GetProductsInBasketTest()
        {
            var basketRepository = new Mock<IBasketRepository>();
            var productRepository = new Mock<IProductRepository>();
            var productBasketRepository = new Mock<IProductBasketRepository>();
            basketRepository.Setup(e => e.GetProductsPageByUserId(It.IsAny<PaginationDTO>())).ReturnsAsync(new PageModelDTO<ProductEntity>());

            var service = new BasketService(basketRepository.Object, productBasketRepository.Object, productRepository.Object, _userData, _mapper);

            var result = await service.GetProductsInBasket(new PaginationDTO { PageNumber = 1, PageSize = 5 });

            Assert.IsType<PageModelDTO<ProductInBasketDTO>>(result);
        }
        [Fact]
        public async Task RemoveProductFromBasketTest()
        {
            var basketRepository = new Mock<IBasketRepository>();
            var productRepository = new Mock<IProductRepository>();
            var productBasketRepository = new Mock<IProductBasketRepository>();
            productBasketRepository.Setup(e => e.RemoveProductFromBasket(It.IsAny<Guid>()));

            var service = new BasketService(basketRepository.Object, productBasketRepository.Object, productRepository.Object, _userData, _mapper);

            var result =  service.RemoveProductFromBasket(Guid.NewGuid());

            Assert.True(result.IsCompletedSuccessfully);
        }
        [Fact]
        public async Task ClearBasketTest()
        {
            var basketRepository = new Mock<IBasketRepository>();
            var productRepository = new Mock<IProductRepository>();
            var productBasketRepository = new Mock<IProductBasketRepository>();
            productBasketRepository.Setup(e => e.ClearBasket());

            var service = new BasketService(basketRepository.Object, productBasketRepository.Object, productRepository.Object, _userData, _mapper);

            var result =  service.ClearBasket();

            Assert.True(result.IsCompletedSuccessfully);
        }

    }
}
