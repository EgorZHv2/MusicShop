using AutoMapper;
using Moq;
using MusicShop.Application.DTO.Filters.Product;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicShop.Tests
{
    public class ProductServiceTests
    {
        private readonly IMapper _mapper;
        public ProductServiceTests() 
        { 
             var myProfile = new AppMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
        [Fact]
        public async Task CreateTest()
        {
            var productPropertyValueRepository = new Mock<IProductPropertyValueRepository>();
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(e => e.Create(It.IsAny<ProductEntity>())).ReturnsAsync(Guid.NewGuid());

            var service = new ProductService(productRepository.Object,_mapper,productPropertyValueRepository.Object);

            var result = await service.Create(new ProductCreateDTO
            {
                CategoryId = Guid.NewGuid(),
                Description = "Desc",
                Discount = 0,
                Name = "Name",
                Price = 322,
                ProductStatus = ProductStatus.InStock,
                QuantityInStock = 100
            });

            Assert.IsType<Guid>(result);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var productPropertyValueRepository = new Mock<IProductPropertyValueRepository>();
            productPropertyValueRepository.Setup(e => e.DeleteAllByProductId(It.IsAny<Guid>()));
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(new ProductEntity());

            var service = new ProductService(productRepository.Object,_mapper,productPropertyValueRepository.Object);

            var result = service.Update(new ProductUpdateDTO
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                Description = "Desc",
                Discount = 0,
                Name = "Name",
                Price = 322,
                ProductStatus = ProductStatus.InStock,
                QuantityInStock = 100
            });

            Assert.True(result.IsCompleted);
        }
        [Fact]
        public async Task UpdateThrowsNotFoundExceptionTest()
        {
            var productPropertyValueRepository = new Mock<IProductPropertyValueRepository>();
            productPropertyValueRepository.Setup(e => e.DeleteAllByProductId(It.IsAny<Guid>()));
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(() => null);

            var service = new ProductService(productRepository.Object,_mapper,productPropertyValueRepository.Object);

            await Assert.ThrowsAsync<ProductNotFoundException>(async () => await service.Update(new ProductUpdateDTO
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                Description = "Desc",
                Discount = 0,
                Name = "Name",
                Price = 322,
                ProductStatus = ProductStatus.InStock,
                QuantityInStock = 100
            }));
        }
         [Fact]
        public async Task GetByIdTest()
        {
            var productPropertyValueRepository = new Mock<IProductPropertyValueRepository>();
            productPropertyValueRepository.Setup(e => e.DeleteAllByProductId(It.IsAny<Guid>()));
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(e => e.GetDetailedById(It.IsAny<Guid>())).ReturnsAsync(new ProductEntity());

            var service = new ProductService(productRepository.Object,_mapper,productPropertyValueRepository.Object);
            var result = await service.GetById(Guid.NewGuid());
             Assert.IsType<ProductDetailedOutputDTO>(result);
        }
         [Fact]
        public async void GetPageTest()
        {
            var productPropertyValueRepository = new Mock<IProductPropertyValueRepository>();
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(e => e.GetPage(It.IsAny<ProductFilter>(), It.IsAny<PaginationDTO>())).ReturnsAsync(new PageModelDTO<ProductEntity>());
            var service = new ProductService(productRepository.Object,_mapper,productPropertyValueRepository.Object);

            var result = await service.GetPage(new ProductFilter(),new PaginationDTO { PageNumber = 1, PageSize =5});
            Assert.IsType<PageModelDTO<ProductOutputDTO>>(result);
        }
         [Fact]
        public async Task DeleteTest()
        {
            var productPropertyValueRepository = new Mock<IProductPropertyValueRepository>();
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(e => e.Delete(It.IsAny<ProductEntity>()));
            productRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(new ProductEntity());

            var service = new ProductService(productRepository.Object,_mapper,productPropertyValueRepository.Object);

            var result =  service.Delete(Guid.NewGuid());
            Assert.True(result.IsCompleted);
        }

    }
}
