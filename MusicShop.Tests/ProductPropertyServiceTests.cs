using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using System;

namespace MusicShop.Tests
{
    public class ProductPropertyServiceTests
    {
        private readonly IMapper mapper;
        public ProductPropertyServiceTests() 
        {
            var myProfile = new AppMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task Create()
        {
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            productPropertyRepository.Setup(e => e.Create(It.IsAny<ProductPropertyEntity>())).ReturnsAsync(Guid.NewGuid());
             
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();
            productPropertySetRepositury.Setup(e => e.CreateMany(It.IsAny<Guid>(), It.IsAny<List<string>>()));
           

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
            var dto = new ProductPropertyCreateDTO
            {
                Name = "Name",
                ValueType = PropertyValueType.Text,
                Values = { "Value1", "Valie2" }
            };
           
            var result = await service.Create(dto);
            Assert.IsType<Guid>(result);
            
        }

        [Fact]
        public async Task GetShortList()
        {
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            productPropertyRepository.Setup(e => e.GetAll()).ReturnsAsync(new List<ProductPropertyEntity> { new ProductPropertyEntity(),new ProductPropertyEntity() });
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
            var result = await service.GetShortList();
            Assert.IsType<List<ProductPropertyShortOutputDTO>>(result);
        }
        [Fact]
        public async Task Delete()
        {
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
           
            productPropertyRepository.Setup(e => e.Delete(It.IsAny<ProductPropertyEntity>()));
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
            await service.Delete(Guid.NewGuid());
            
            Assert.True(service.Delete(Guid.NewGuid()).IsCompletedSuccessfully);
        }
        [Fact]
        public async Task GetById()
        {
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var guid = Guid.NewGuid();
            productPropertyRepository.Setup(e => e.GetByIdWithSet(It.IsAny<Guid>())).ReturnsAsync(new ProductPropertyEntity{ Id = guid, Name = "Name" });
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
            var dto = await service.GetById(guid);

            Assert.NotNull(dto); 
            Assert.Equal(guid, dto.Id);
            Assert.Equal("Name", dto.Name);
           
        }

        [Fact]
        public async Task GetByIdNotFoundException()
        {
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
         
            productPropertyRepository.Setup(e => e.GetByIdWithSet(It.IsAny<Guid>())).ReturnsAsync(()=>null);
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
          
            await Assert.ThrowsAsync<ProductPropertyNotFoundException>(()=> service.GetById( Guid.NewGuid()));
           
        }
        [Fact]
        public async Task UpdateNotFoundException()
        {
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            productPropertyRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(()=>null);
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
          
            await Assert.ThrowsAsync<ProductPropertyNotFoundException>(()=> service.Update(new  ProductPropertyUpdateDTO{ Id = Guid.NewGuid(),Name = "Name"}));
        }
        [Fact]
        public async Task GetPage()
        {
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var entities = new List<ProductPropertyEntity> { new ProductPropertyEntity { Id = Guid.NewGuid(), Name = "Name" }, new ProductPropertyEntity { Id = Guid.NewGuid(), Name = "Name" } };

            productPropertyRepository.Setup(e => e.GetPage(It.IsAny<PaginationDTO>()))
                .ReturnsAsync(new PageModelDTO<ProductPropertyEntity> {ItemsOnPage = 5,TotalItems = 2,CurrentPage =1,TotalPages = 1, Values =entities });
           

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
            var result = await service.GetPage(new PaginationDTO { PageNumber = 1,PageSize = 5});
            Assert.IsType<PageModelDTO<ProductPropertyOutputDTO>>(result);
        }
        [Fact]
        public async Task GetProptiesByCategoryId()
        {
            var productPropertySetRepositury = new Mock<IProductPropertySetRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
           

            productPropertyRepository.Setup(e => e.GetPropertiesByCategoryId(It.IsAny<Guid>()))
                .ReturnsAsync(new List<ProductPropertyEntity>{ new ProductPropertyEntity { Id = Guid.NewGuid(), Name = "Name" }, new ProductPropertyEntity { Id = Guid.NewGuid(), Name = "Name" } });
           

            var service = new ProductPropertyService(productPropertyRepository.Object,mapper,productPropertySetRepositury.Object);
            var result = await service.GetPropertiesByCategoryId(Guid.NewGuid());
            Assert.IsType<List<ProductPropertyOutputDTO>>(result);
        }
    }
}
