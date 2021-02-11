using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class RideStop
    {
        [Key]
        public int IdRideStop { get; set; }
        public Ride Ride { get; set; }
        public Location Location { get; set; }
    }
}
