using Microsoft.EntityFrameworkCore;
using MusicShop.Domain.Entities;
using MusicShop.Persistance.Contexts;
using MusicShop.Application.DTO.PageModels;
using MusicShop.Application.Interfaces.Repositories;
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

        public virtual async Task<PageModelDTO<TEntity>> GetPage(PaginationDTO pagination)
        {
            var result = await ToPageModel<TEntity>(_dbset, pagination);
            return result;
        }

        public virtual async Task<TEntity?> GetById(Guid Id)
        {
            return await _dbset.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public  async  Task<IEnumerable<TEntity>> GetManyByIds(ICollection<Guid> ids)
        {
            return await _dbset.Where(e => ids.Contains(e.Id)).ToListAsync();
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

        protected async Task<PageModelDTO<T>> ToPageModel<T>(IQueryable<T> values,PaginationDTO dto)
        {
            return new PageModelDTO<T>
            {
                Values = await values.Skip((dto.PageNumber - 1) * dto.PageSize).Take(dto.PageSize).ToListAsync(),
                ItemsOnPage = dto.PageSize,
                CurrentPage = dto.PageNumber,
                TotalItems = values.Count(),
                TotalPages = (int)Math.Ceiling(_dbset.Count() / (double)dto.PageSize)
            };
        }

    }
}
