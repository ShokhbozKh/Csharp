using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Booking
    {
        [Key]
        public int IdBooking { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}
