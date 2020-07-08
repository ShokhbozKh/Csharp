using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public class Seat
    {
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int IdSeat { get; set; }
        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }
        public int BusId { get; set; }
        public bool IsAtWindow { get; set; }

        [ForeignKey("BusId")]
        public virtual Bus Bus { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
