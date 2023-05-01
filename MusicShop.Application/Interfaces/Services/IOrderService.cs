using MusicShop.Application.DTO.Order;
using MusicShop.Application.DTO.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Guid> Create(OrderCreateDTO dto);
        Task UpdateOrderStatus(OrderUpdateDTO dto);
        Task<PageModelDTO<OrderOutputDTO>> GetPage(PaginationDTO dto);
        Task<OrderDetailedOutputDTO> GetById(Guid id);
        Task Delete(Guid id);
    }
}
