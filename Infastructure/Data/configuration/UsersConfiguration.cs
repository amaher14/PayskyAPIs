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
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {

        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
                .IsRequired(true);
            builder.Property(x => x.Passowrd)
                .IsRequired(true);
            builder.Property(x => x.UserType)
                   .IsRequired(true);
            builder.Property(x => x.FullName)
                   .IsRequired(true);
            builder.Property(x => x.PhoneNumber)
                  .IsRequired(true);

        }
    }
}
