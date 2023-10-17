using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Data.Configuration
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.JobTitle)
                .IsRequired(true);
            builder.Property(x => x.Department)
                .IsRequired(true);
            builder.Property(x => x.UserId)
                   .IsRequired(true);

            builder.HasOne(c => c.Users)
                      .WithOne()
                      .HasForeignKey<Employer>(_ => _.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
