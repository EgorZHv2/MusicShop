using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<Guid> Create(ProductCreateDTO dto);
        Task Update(ProductUpdateDTO dto);
        Task<ProductDetailedOutputDTO> GetById(Guid id);
        Task<PageModelDTO<ProductOutputDTO>> GetPage(PaginationDTO dto);
        Task Delete(Guid id);
    }
}
