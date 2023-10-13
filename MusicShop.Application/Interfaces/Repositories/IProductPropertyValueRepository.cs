namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IProductPropertyValueRepository
    {
        Task DeleteAllByProductId(Guid id);
    }
}