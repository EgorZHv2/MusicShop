using AutoMapper;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using MusicShop.Application.Exceptions;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Services
{
    public class BasketService:IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductBasketRepository _productBasketRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserData _userData;
        private readonly IMapper _mapper;
        public BasketService
        (
            IBasketRepository basketRepository, 
            IProductBasketRepository productBasketRepository, 
            IProductRepository productRepository,
            UserData userData,
            IMapper mapper
        )
        {
            _basketRepository = basketRepository;
            _productBasketRepository = productBasketRepository;
            _productRepository = productRepository;
            _userData = userData;
            _mapper = mapper;
        }
        public async Task AddProductToBasket(Guid productId)
        {
            var basket = await _basketRepository.GetBasketByUserId(_userData.Id);
            var product = await _productRepository.GetById(productId);
            if(product == null)
            {
                throw new ProductNotFoundException();
            }
            basket.Products.Add(product );
            await _productBasketRepository.ClearBasket();
            await _basketRepository.Update(basket);


        }
        public async Task<PageModelDTO<ProductInBasketDTO>> GetProductsInBasket(PaginationDTO dto)
        {
            var pages = await _basketRepository.GetProductsPageByUserId(dto);
            var result = _mapper.Map<PageModelDTO<ProductInBasketDTO>>(pages);
            return result;

        }
        public async Task RemoveProductFromBasket(Guid productId)
        {
           await _productBasketRepository.RemoveProductFromBasket(productId);
        }
        public async Task ClearBasket()
        {
           
            await _productBasketRepository.ClearBasket();
        }

    }
}
