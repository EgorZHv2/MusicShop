using MusicShop.Application.DTO.Category;
using MusicShop.Application.DTO.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Guid> Create(CategoryCreateDTO dto);
        Task Update(CategoryUpdateDTO dto);
        Task<List<CategoryShortOutputDTO>> GetShortList();
        Task<PageModelDTO<CategoryOutputDTO>> GetPage(PaginationDTO dto);
        Task<CategoryOutputDTO> GetById(Guid id);
        Task Delete(Guid id);
    }
}
