using System.Collections.Generic;

namespace Domain.Entities
{
    public class Ride
    {
        public Ride()
        {
            RideStops = new List<RideStop>();
        }

        public int RideId { get; set; }
        public double TotalHours { get; set; }
        public int StartPointId { get; set; }
        public int DestinationPointId { get; set; }

        public Location StartPoint { get; set; }
        public Location DestinationPoint { get; set; }

        public ICollection<RideStop> RideStops { get; private set; }
    }
}
