using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class TicketSeats
    {
        [Key]
        public int IdTicketSeats { get; set; }
        public int TicketId { get; set; }
        public int SeatId { get; set; }

        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }
    }
}
