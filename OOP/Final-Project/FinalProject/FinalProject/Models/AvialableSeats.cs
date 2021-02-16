using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class AvialableSeats
    {
        [Key]
        public int AvialableSeatsId { get; set; }

        public int SeatId { get; set; }
        public int BusId { get; set; }
        public int RideScheduleId { get; set; }
        [Required]
        public bool IsAvialable { get; set; }

        [ForeignKey("RideScheduleId")]
        public RideSchedule RideSchedule { get; set; }
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }
        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
    }
}
