using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class RideSchedule
    {
        [Key]
        public int IdRideSchedule { get; set; }
        public int RideDateId { get; set; }
        public int ScheduleId { get; set; }
        public int AvialableSeatsId { get; set; }

        [ForeignKey("RideDateId")]
        public RideDate RideDate { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; }
        [ForeignKey("AvialableSeatsId")]
        public AvialableSeats AvialableSeats { get; set; }
    }
}
