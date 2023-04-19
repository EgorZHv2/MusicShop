using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.ProductProperty;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IProductPropertyService
    {
        Task<Guid> Create(ProductPropertyCreateDTO dto);

        Task<List<ProductPropertyShortOutputDTO>> GetShortList();

        Task Delete(Guid id);

        Task<PageModelDTO<ProductPropertyOutputDTO>> GetPage(PaginationDTO paginationDTO);
        Task Update(ProductPropertyUpdateDTO dto);
        Task<ProductPropertyOutputDTO> GetById(Guid id);
        Task<List<ProductPropertyOutputDTO>> GetProptiesByCategoryId(Guid id);
    }
}
