using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }
        public Guid TicketNumber { get; set; }
        public decimal Price { get; set; }
        public string BookedByFullname { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }


        public TicketClassAttribute TicketClassAttribute { get; set; }
        public Bus Bus { get; set; }
        public Seat Seat { get; set; }
        public DiscountReason DiscountReason { get; set; }

        [EnumDataType(typeof(TicketStatus))]
        public TicketStatus TicketStatus { get; set; }
        [EnumDataType(typeof(TicketType))]
        public TicketType TicketType { get; set; }
    }
}
