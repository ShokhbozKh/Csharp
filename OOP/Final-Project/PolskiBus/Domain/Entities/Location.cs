using System.Collections.Generic;

namespace Domain.Entities
{
    public class Location
    {
        public Location()
        {
            Rides = new List<Ride>();
            RideStops = new List<RideStop>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string StationName { get; set; }

        public ICollection<Ride> Rides { get; private set; }
        public ICollection<RideStop> RideStops { get; private set; }
    }
}
