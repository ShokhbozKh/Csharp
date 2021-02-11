using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Ride
    {
        [Key]
        public int IdRide { get; set; }
        public Location StartPoint { get; set; }
        public Location DestinationPoint { get; set; }
        public string StartStation { get; set; }
        public string DestinationStation { get; set; }
        public double TotalHours { get; set; }
    }
}
