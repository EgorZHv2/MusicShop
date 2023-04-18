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
        Task<Guid> Create(CreateCategoryDTO dto);
        Task Update(UpdateCategoryDTO dto);
        Task<List<OutputShortCategoryDTO>> GetShortList();
        Task<PageModelDTO<OutputCategoryDTO>> GetPage(PaginationDTO dto);
        Task<OutputCategoryDTO> GetById(Guid id);
        Task Delete(Guid id);
    }
}
