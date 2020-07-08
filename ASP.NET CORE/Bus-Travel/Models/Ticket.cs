using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public decimal? Price { get; set; }
        public string BookedForLastName { get; set; }
        public DateTime? BookingDateTime { get; set; }
        public int TicketStatusId { get; set; }
        public int TicketTypeId { get; set; }
        public int DisplayingId { get; set; }
        public int SeatId { get; set; }
        public int BookedByUserId { get; set; }
        public int? DiscountReason { get; set; }


        [ForeignKey("DisplayingId")]
        public virtual Displaying Displaying { get; set; }
        [ForeignKey("BusId")]
        public virtual Bus Bus { get; set; }
        [ForeignKey("SeatId")]
        public virtual Seat Seat { get; set; }
    }
}
