using AutoMapper;
using Microsoft.OpenApi.Writers;
using Moq;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MusicShop.Application.DTO.Order;
using MusicShop.Application.DTO.PageModels;

namespace MusicShop.Tests
{
    public class OrderServiceTests
    {
        private readonly IMapper _mapper;
        private readonly UserData _userData = new UserData { Id = Guid.NewGuid() }; 
        public OrderServiceTests() 
        { 
             var myProfile = new AppMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
        [Fact]
        public async Task CreateTest()
        {
            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(e=>e.Create(It.IsAny<OrderEntity>())).ReturnsAsync(Guid.NewGuid());
            var service = new OrderService(orderRepository.Object,_userData, _mapper);
            var result = await service.Create(new OrderCreateDTO());
            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task UpdateOrderStatusNotFoundExceptionTest()
        {
            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(e => e.Update(It.IsAny<OrderEntity>()));
            orderRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(() => null);
            var service = new OrderService(orderRepository.Object,_userData, _mapper);
            
            await Assert.ThrowsAsync<OrderNotFoundException>(async()=>await service.UpdateOrderStatus(new OrderUpdateDTO()));
        }
        [Fact]
        public async Task GetPageTest()
        {
            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(e => e.GetPage(It.IsAny<PaginationDTO>())).ReturnsAsync(new PageModelDTO<OrderEntity>());
           
            var service = new OrderService(orderRepository.Object,_userData, _mapper);
            var result = await service.GetPage(new PaginationDTO { PageNumber=1,PageSize=5});
            
            Assert.IsType<PageModelDTO<OrderOutputDTO>>(result);
        }
        [Fact]
        public async Task GetByIdTest()
        {
            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(e => e.GetById(It.IsAny<Guid>())).ReturnsAsync(new OrderEntity());
            var service = new OrderService(orderRepository.Object,_userData, _mapper);
            var result = await service.GetById(Guid.NewGuid());
            Assert.IsType<OrderDetailedOutputDTO>(result);
        }
        [Fact]
        public async Task DeleteTest()
        {
            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(e => e.Delete(It.IsAny<OrderEntity>()));
            var service = new OrderService(orderRepository.Object,_userData, _mapper);
            var result =  service.Delete(Guid.NewGuid());
            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
