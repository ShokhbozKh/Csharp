namespace Domain.Entities
{
    public class RideStop
    {
        public int RideStopId { get; set; }
        public int RideId { get; set; }
        public int LocationId { get; set; }

        public Ride Ride { get; set; }
        public Location Location { get; set; }
    }
}
