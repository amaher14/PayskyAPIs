using Core.Common;
using Infastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PaySkyDbContext _dbContext;

        public UnitOfWork(PaySkyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            var result = await _dbContext.SaveChangesAsync(CancellationToken.None);
            DetachAllEntities();

            return result;
        }
        public void DetachAllEntities()
        {
            var changedEntriesCopy = _dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted ||
                            e.State == EntityState.Unchanged
                            )
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }
    }
}