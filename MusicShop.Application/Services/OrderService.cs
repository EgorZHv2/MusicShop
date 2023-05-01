using AutoMapper;
using MusicShop.Application.DTO.Order;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Exceptions;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Application.Interfaces.Services;
using MusicShop.Domain.Entities;
using MusicShop.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserData _userData;
        private readonly IMapper _mapper;
        public OrderService (IOrderRepository orderRepository, UserData userData,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userData = userData;
            _mapper = mapper;
        }
        public async Task<Guid> Create(OrderCreateDTO dto)
        {
            var entity = _mapper.Map<OrderEntity>(dto);
            entity.UserId = _userData.Id;
            entity.OrderStatus = Domain.Enums.OrderStatus.Processed;
            var result  = await _orderRepository.Create(entity);
            return result;
        }
        public async Task UpdateOrderStatus(OrderUpdateDTO dto)
        {
            var existingEntity = await _orderRepository.GetById(dto.Id);
            if(existingEntity == null)
            {
                throw new OrderNotFoundException();
            }
            _mapper.Map(dto, existingEntity);
            await _orderRepository.Update(existingEntity);
        }
        public async Task<PageModelDTO<OrderOutputDTO>> GetPage(PaginationDTO dto)
        {
            var pages = await _orderRepository.GetPage(dto);
            var result = _mapper.Map<PageModelDTO<OrderOutputDTO>>(pages);
            return result;
        }
        public async Task<OrderDetailedOutputDTO> GetById(Guid id)
        {
            var entity = await _orderRepository.GetById(id);
            var result = _mapper.Map<OrderDetailedOutputDTO>(entity);
            return result;
        }
        public async Task Delete(Guid id)
        {
            var entity = await _orderRepository.GetById(id);
            if (entity != null)
               await _orderRepository.Delete(entity);
        }
            
    }
}
