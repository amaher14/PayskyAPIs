using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Data.Configuration
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status)
                .IsRequired(true);
            builder.Property(x => x.Description)
               .IsRequired(true);
            builder.Property(x => x.ExpireDate)
               .IsRequired(true);
            builder.Property(x => x.JobTitle)
             .IsRequired(true);
            builder.Property(x => x.MaxApplications)
             .IsRequired(true);
   
        }
    }
}
