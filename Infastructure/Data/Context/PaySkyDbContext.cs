using Core;
using Core.Entities;
using Infastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Infastructure.Data.Context
{

    public class PaySkyDbContext : DbContext
    {
        public PaySkyDbContext()
        { }
        public PaySkyDbContext(DbContextOptions<PaySkyDbContext> options) : base(options)
        {
    
        }
        DbSet<Applicant> Applicant { get; set; }
        DbSet<Application> Application { get; set; }
        DbSet<Employer> Employer { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Vacancy> Vacancy { get; set; }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           builder.ApplyConfiguration(new ApplicantConfiguration());
           builder.ApplyConfiguration(new EmployerConfiguration());
           builder.ApplyConfiguration(new UsersConfiguration());
           builder.ApplyConfiguration(new VacancyConfiguration());
           builder.ApplyConfiguration(new ApplicantConfiguration());
          

        }
        private void AuditTrail()
        {
            var userId = Guid.Parse("712690af-7327-4947-b7ec-3f58f2e3b50b");//_currentUserService.CurrentUserId;
            ChangeTracker.DetectChanges();
            var added = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in added)
            {
                if (entity is AuditableEntity<Guid> trackGuid)
                {
                    trackGuid.Id = trackGuid.Id != Guid.Empty ? trackGuid.Id : userId;
                    trackGuid.IsDeleted = false;
                    trackGuid.CreatedAt = DateTime.Now;
                    trackGuid.CreatedBy = userId;
                    trackGuid.LastModificationAt = DateTime.Now;
                    trackGuid.LastModificationBy = userId;
                }
                if (entity is AuditableEntity<int> trackInt)
                {
                    trackInt.CreatedAt = DateTime.Now;
                    trackInt.CreatedBy = userId;
                    trackInt.LastModificationAt = DateTime.Now;
                    trackInt.LastModificationBy = userId;
                }
            }

            var modified = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in modified)
            {
                if (entity is AuditableEntity<Guid> trackGuid)
                {
                    trackGuid.LastModificationAt = DateTime.Now;
                    trackGuid.LastModificationBy = userId;
                }
                if (entity is AuditableEntity<int> trackInt)
                {
                    trackInt.LastModificationAt = DateTime.Now;
                    trackInt.LastModificationBy = userId;
                }
            }
        }
        public override int SaveChanges()
        {
            AuditTrail();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            AuditTrail();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}
