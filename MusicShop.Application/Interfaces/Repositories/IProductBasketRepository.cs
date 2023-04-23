namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IProductBasketRepository
    {
        Task ClearBasket();
        Task RemoveProductFromBasket(Guid productId);
    }
}