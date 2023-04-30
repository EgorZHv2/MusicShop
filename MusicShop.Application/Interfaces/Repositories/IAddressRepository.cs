using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IAddressRepository : IBaseEntityRepository<AddressEntity>
    {
        Task<AddressEntity?> GetLastAddressByUserId(Guid userId);
    }
}