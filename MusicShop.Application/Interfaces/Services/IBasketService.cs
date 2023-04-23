using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Exceptions;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IBasketService
    {
        Task AddProductToBasket(Guid productId);
        Task<PageModelDTO<ProductOutputDTO>> GetProductsInBasket(PaginationDTO dto);
        Task RemoveProductFromBasket(Guid productId);
        Task ClearBasket();
    }
}
