using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Data.configuration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VacancyId)
                .IsRequired(true);
            builder.Property(x => x.ApplicationStatus)
        .IsRequired(true);
  

            builder.HasOne(c => c.Applicant)
         .WithOne()
         .HasForeignKey<Applicant>(_=>_.Id)
         .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
