using System.Linq.Expressions;
using X.PagedList;

namespace Core.Common
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(params object[] keys);
        Task<IList<TEntity>> GetAllAsync(string[] children);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(object id);
        Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities);
        Task<bool> RemoveRange(IEnumerable<TEntity> entities);
        Task<ICollection<TEntity>> UpdateRange(ICollection<TEntity> entities);
        Task<IList<TEntity>> GetAllAsync();
        Task<IList<TEntity>> GetBy(Expression<Func<TEntity, bool>> filter = null, string[] children = null);
        Task<List<TEntity>> GetByPagedList(Expression<Func<TEntity, bool>> filter = null, string[] children = null,int? pageSize = 1,int? PageNumber = 10);
        Task<TEntity> DeleteByEntity(TEntity entity);
    }
}
