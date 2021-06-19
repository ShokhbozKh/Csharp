using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LocationConfiguration
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(p => p.LocationId);

            builder.Property(p => p.LocationName).HasMaxLength(100).IsRequired();
            
            builder.Property(p => p.StationName).HasMaxLength(100).IsRequired();
        }
    }
}
