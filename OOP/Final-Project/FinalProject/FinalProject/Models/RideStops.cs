using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class RideStop
    {
        [Key]
        public int IdRideStop { get; set; }
        public int RideId { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
