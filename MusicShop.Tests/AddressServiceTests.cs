using AutoMapper;
using Moq;
using MusicShop.Application.DTO.Address;
using MusicShop.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicShop.Tests
{
    public class AddressServiceTests
    {
        private readonly IMapper _mapper;
        private readonly UserData _userData = new UserData { Id = Guid.NewGuid() }; 
        public AddressServiceTests() 
        { 
             var myProfile = new AppMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
        [Fact]
        public async Task CreateTest()
        {
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(e=>e.Create(It.IsAny<AddressEntity>())).ReturnsAsync(Guid.NewGuid());

            var service = new AddressService(addressRepository.Object,_mapper,_userData);

            var result =  await service.Create(new AddressCreateDTO());

            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task GetByIdTest()
        {
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(e=>e.GetById(It.IsAny<Guid>())).ReturnsAsync(new AddressEntity());

            var service = new AddressService(addressRepository.Object,_mapper,_userData);

            var result =  await service.GetById(Guid.NewGuid());

            Assert.IsType<AddressOutputDTO>(result);
        }
         [Fact]
        public async Task GetLastAddressByUserIdTest()
        {
            var addressRepository = new Mock<IAddressRepository>();
            addressRepository.Setup(e=>e.GetLastAddressByUserId(It.IsAny<Guid>())).ReturnsAsync(new AddressEntity());

            var service = new AddressService(addressRepository.Object,_mapper,_userData);

            var result =  await service.GetLastAddressByUserId();

            Assert.IsType<AddressOutputDTO>(result);
        }
    }
}
