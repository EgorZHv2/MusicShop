namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IProductPropertySetRepository
    {
        Task CreateMany(Guid propertyId, List<string> values);
        Task DeleteAllByPropertyId(Guid propertyId);
    }
}