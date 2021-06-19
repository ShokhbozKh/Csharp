using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RideStopConfiguration
    {
        public void Configure(EntityTypeBuilder<RideStop> builder)
        {
            builder.HasKey(p => p.RideStopId);

            builder.HasOne(p => p.Ride)
                .WithMany(r => r.RideStops)
                .HasForeignKey(p => p.RideId)
                .HasConstraintName("Ride_FK");

            builder.HasOne(p => p.Location)
                .WithMany(l => l.RideStops)
                .HasForeignKey(p => p.LocationId)
                .HasConstraintName("Location_FK");
        }
    }
}
