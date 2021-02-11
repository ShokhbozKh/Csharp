using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Displaying
    {
        [Key]
        public int IdDisplaying { get; set; }
        public decimal StandardPrice { get; set; }
        public int AvialableSeats { get; set; }
        public bool IsDeparted { get; set; }

        public int RideId { get; set; }
        public int TicketId { get; set; }
        public int BusId { get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
    }
}
