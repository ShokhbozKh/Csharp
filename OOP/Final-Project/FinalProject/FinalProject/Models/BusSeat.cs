using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class BusSeat
    {
        [Key]
        public int BusSeatId { get; set; }

        public int BusId { get; set; }
        public int SeatId { get; set; }
        public bool IsAvialable { get; set; }

        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }
    }
}
