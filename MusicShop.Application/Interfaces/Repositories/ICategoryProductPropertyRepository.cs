namespace MusicShop.Application.Interfaces.Repositories
{
    public interface ICategoryProductPropertyRepository
    {
       Task DeleteAllByCategoryId(Guid categoryId);
    }
}