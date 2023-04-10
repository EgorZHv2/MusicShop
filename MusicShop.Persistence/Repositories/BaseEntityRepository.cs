using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Persistance.Repositories
{
    public class BaseEntityRepository<TEntity>:IBaseEntityRepository<TEntity> where TEntity:BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbset;

        public BaseEntityRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetById(Guid Id)
        {
            return await _dbset.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public  IEnumerable<TEntity> GetManyByIds(ICollection<Guid> ids)
        {
            return _dbset.Where(e => ids.Contains(e.Id));
        }

        

        public virtual async Task<Guid> Create(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task CreateMany(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedAt = DateTime.UtcNow;
            }
            await _dbset.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMany(ICollection<TEntity>entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
            _dbset.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            entity.DeletedAt = DateTime.UtcNow;
            entity.IsDeleted = true;
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DeletedAt = DateTime.UtcNow;
            }
            _dbset.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task HardDelete(TEntity entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task HardDeleteMany(ICollection<TEntity> entities)
        {
            _dbset.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
