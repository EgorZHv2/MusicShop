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
        Task<Guid> Create(CreateProductPropertyDTO dto);

        Task<List<OutputShortProductPropertyDTO>> GetShortList();

        Task Delete(Guid id);

        Task<PageModelDTO<OutputProductPropertyDTO>> GetPage(PaginationDTO paginationDTO);
        Task Update(UpdateProductPropertyDTO dto);
        Task<OutputProductPropertyDTO> GetById(Guid id);
    }
}
