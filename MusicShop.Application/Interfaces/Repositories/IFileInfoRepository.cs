using MusicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Interfaces.Repositories
{
    public interface IFileInfoRepository:IBaseEntityRepository<FileInfoEntity>
    {
        Task<IEnumerable<string>> GetFilesNamesByParentId(Guid id);
        Task HardDeleteAllByParentId(Guid Id);
    }
}
