using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class BusDbContext : DbContext
    {
        public BusDbContext(DbContextOptions<BusDbContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<RideStop> RideStops { get; set; }
    }
}
