using MusicShop.Application.DTO.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Services
{
    public interface IFileService
    {
        Task Create(FileCreateDTO dto);
        Task DeleteAllByParentEntityId(Guid entityId);
        Task<IEnumerable<string>> GetFilesUrisByParentId(Guid id);
    }
}
