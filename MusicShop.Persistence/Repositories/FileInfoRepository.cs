using Microsoft.EntityFrameworkCore;
using MusicShop.Application.Interfaces.Repositories;
using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories
{
    public class FileInfoRepository:BaseEntityRepository<FileInfoEntity>,IFileInfoRepository
    {
        public FileInfoRepository(ApplicationDbContext context):base(context) { }
        public async Task<IEnumerable<FileInfoEntity>> GetFilesNamesByParentId(Guid id)
        {
            
            return await _dbset.Where(e=>e.ParentEntityId == id).ToListAsync();
        }
        public async Task HardDeleteAllByParentId(Guid Id)
        {
            var entities = _dbset.Where(e => e.ParentEntityId == Id);
            _dbset.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
