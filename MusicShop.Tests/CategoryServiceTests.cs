using AutoMapper;
using Moq;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShop.Application.DTO.Category;
using MusicShop.Domain.Entities;
using MusicShop.Application.DTO.PageModels;

namespace MusicShop.Tests
{
    public class CategoryServiceTests
    {
        private readonly IMapper _mapper;
        public CategoryServiceTests() 
        { 
            var myProfile = new AppMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
        [Fact]
        public async Task CreateTest()
        {
            var categoryRepository = new Mock<ICategoryRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var categoryProductPropertyRepository = new Mock<ICategoryProductPropertyRepository>();

            categoryRepository.Setup(e => e.Create(It.IsAny<CategoryEntity>())).ReturnsAsync(Guid.NewGuid());
            categoryRepository.Setup(e => e.Update(It.IsAny<CategoryEntity>()));
            productPropertyRepository.Setup(e => e
            .GetManyByIds(new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }))
                .ReturnsAsync(new List<ProductPropertyEntity> { new ProductPropertyEntity(),new ProductPropertyEntity(),new ProductPropertyEntity()});
            var service = new CategoryService(categoryRepository.Object, _mapper, productPropertyRepository.Object, categoryProductPropertyRepository.Object);
            var result = await service.Create(new CategoryCreateDTO());

            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task UpdateNotFoundExceptionTest()
        {
            var categoryRepository = new Mock<ICategoryRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var categoryProductPropertyRepository = new Mock<ICategoryProductPropertyRepository>();

            categoryRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(()=>null);
            var service = new CategoryService(categoryRepository.Object, _mapper, productPropertyRepository.Object, categoryProductPropertyRepository.Object);
            await Assert.ThrowsAsync<CategoryNotFoundException>(async ()=>await service.Update(new CategoryUpdateDTO()));
        }
        [Fact]
        public async Task GetShortTest()
        {
            var categoryRepository = new Mock<ICategoryRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var categoryProductPropertyRepository = new Mock<ICategoryProductPropertyRepository>();

            categoryRepository.Setup(e => e.GetAll()).ReturnsAsync(new List<CategoryEntity> { new CategoryEntity(),new CategoryEntity(),new CategoryEntity()});
            
            var service = new CategoryService(categoryRepository.Object, _mapper, productPropertyRepository.Object, categoryProductPropertyRepository.Object);
            var result = await service.GetShortList();

            Assert.IsType<List<CategoryShortOutputDTO>>(result);
        }
        [Fact]
        public async Task GetPageTest()
        {
            var categoryRepository = new Mock<ICategoryRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var categoryProductPropertyRepository = new Mock<ICategoryProductPropertyRepository>();

            categoryRepository.Setup(e => e.GetPage(It.IsAny<PaginationDTO>())).ReturnsAsync(new PageModelDTO<CategoryEntity>());
            
            var service = new CategoryService(categoryRepository.Object, _mapper, productPropertyRepository.Object, categoryProductPropertyRepository.Object);
            var result = await service.GetPage(new PaginationDTO());

            Assert.IsType<PageModelDTO<CategoryOutputDTO>>(result);
        }
        [Fact]
        public async Task GetByIdTest()
        {
            var categoryRepository = new Mock<ICategoryRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var categoryProductPropertyRepository = new Mock<ICategoryProductPropertyRepository>();

            categoryRepository.Setup(e => e.GetByIdWithProperties(It.IsAny<Guid>())).ReturnsAsync(new CategoryEntity());
            
            var service = new CategoryService(categoryRepository.Object, _mapper, productPropertyRepository.Object, categoryProductPropertyRepository.Object);
            var result = await service.GetById(Guid.NewGuid());

            Assert.IsType<CategoryOutputDTO>(result);
        }
        [Fact]
        public async Task DeleteTest()
        {
            var categoryRepository = new Mock<ICategoryRepository>();
            var productPropertyRepository = new Mock<IProductPropertyRepository>();
            var categoryProductPropertyRepository = new Mock<ICategoryProductPropertyRepository>();

            categoryRepository.Setup(e => e.Delete(It.IsAny<CategoryEntity>()));
              categoryRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(new CategoryEntity());
           
            
            var service = new CategoryService(categoryRepository.Object, _mapper, productPropertyRepository.Object, categoryProductPropertyRepository.Object);
            var result =  service.Delete(Guid.NewGuid());

            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
