using Exercise_08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_08.Configurations
{
    public class AnimalClinicConfigurationType : IEntityTypeConfiguration<AnimalClinic>
    {
        public void Configure(EntityTypeBuilder<AnimalClinic> builder)
        {
            builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
            throw new NotImplementedException();
        }
    }
}
