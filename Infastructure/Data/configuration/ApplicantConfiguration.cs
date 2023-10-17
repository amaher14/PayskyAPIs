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
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId)
                .IsRequired(true);
            builder.Property(x => x.Email)
               .IsRequired(true);

            builder.HasOne(c => c.Users)
                 .WithOne()
                 .HasForeignKey<Applicant>(_ => _.UserId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
