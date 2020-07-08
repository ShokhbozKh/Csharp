using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAS_Final.Models
{
    public partial class Ride
    {
        public Ride()
        {
            Buses = new HashSet<Bus>();
            DisplayingRides = new HashSet<DisplayingRide>();
        }

        [Key]
        public int IdRide { get; set; }
        [Required, MaxLength(500)]
        public string StartPoint { get; set; }
        [Required, MaxLength(500)]
        public string DestinationPoint { get; set; }
        [Required]
        public double TotalRideTime  { get; set; }

        public virtual ICollection<DisplayingRide> DisplayingRides { get; set; }
        public virtual ICollection<Bus> Buses { get; set; }
    }
}
