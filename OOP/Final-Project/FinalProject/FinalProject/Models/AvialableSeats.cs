using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class AvialableSeats
    {
        [Key]
        public int BusSeatId { get; set; }

        public int RideId { get; set; }
        public int SeatId { get; set; }
        public int BusId { get; set; }
        [Required]
        public bool IsAvialable { get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }
        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
    }
}
