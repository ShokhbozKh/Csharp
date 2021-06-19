using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RideConfiguration
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
            builder.HasKey(p => p.RideId);

            builder.HasOne(p => p.StartPoint)
                .WithMany(l => l.Rides)
                .HasForeignKey(p => p.StartPointId)
                .HasConstraintName("StartPoint_FK");

            builder.HasOne(p => p.DestinationPoint)
                .WithMany(l => l.Rides)
                .HasForeignKey(p => p.DestinationPointId)
                .HasConstraintName("DestinationPoint_FK");

            builder.Property(p => p.TotalHours)
                .IsRequired(false);
        }
    }
}
