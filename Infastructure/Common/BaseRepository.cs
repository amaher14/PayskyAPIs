
using Core.Common;
using Infastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.PagedList;

namespace Infastructure
{

    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
          where TEntity : class
    {
        private readonly PaySkyDbContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(PaySkyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        
        public async Task<TEntity> GetByIdAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys);
        }
        public async Task<IList<TEntity>> GetAllAsync(string[] children)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (string entity in children)
            {
                query = query.Include(entity);

            }
            return await query.AsNoTracking().ToListAsync();

        }

      
        public async Task<IList<TEntity>> GetAllAsync()
        {

            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> GetBy(Expression<Func<TEntity, bool>> filter = null, string[] children = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (children != null)
            {
                foreach (string entity in children)
                {
                    query = query.Include(entity);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Add(entity);
            }

            return entity;
        }

        public async Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities)
        {
            _dbSet.AddRange(entities);

            return entities;
        }

        public async Task<ICollection<TEntity>> UpdateRange(ICollection<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);

            return entities;
        }
        public async Task<bool> RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                return  true;

            }
            catch (Exception)
            {

                return false;
            }
            
          

        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;

            return entity;
        }

        public async Task<TEntity> Delete(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _dbSet.Remove(entity);
            //Why.
            //await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteByEntity(TEntity entity)
        {
            if (entity == null)
            {
                return entity;
            }

            _dbSet.Remove(entity);
            //await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IQueryable<TEntity>> GetQueryableAsNoTracking()
        {

            return _dbSet.AsNoTracking();
        }

        public async Task<List<TEntity>> GetByPagedList(Expression<Func<TEntity, bool>> filter = null, string[] children = null, int? pageSize = 10, int? PageNumber = 1)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (children != null)
            {
                foreach (string entity in children)
                {
                    query = query.Include(entity);
                }
            }
           var pagedList=await query.ToPagedListAsync(PageNumber.Value,pageSize.Value);
            return pagedList.ToList();
        }
    }
}
