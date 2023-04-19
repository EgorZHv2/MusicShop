using MusicShop.Domain.Entities;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IUserRepository : IBaseEntityRepository<UserEntity>
    {
        Task<UserEntity?> GetUserByEmail(string email);
    }
}