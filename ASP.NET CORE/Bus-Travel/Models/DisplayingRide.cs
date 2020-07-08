using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public class DisplayingRide
    {
        [Key]
        public int IdDisplayingRide { get; set; }
        public int DisplayingOrder { get; set; }
        public int RideId { get; set; }
        public int DisplayingId { get; set; }

        [ForeignKey("RideId")]
        public virtual Ride Ride { get; set; }
        [ForeignKey("DisplayingId")]
        public virtual Displaying Displaying { get; set; }
    }
}
