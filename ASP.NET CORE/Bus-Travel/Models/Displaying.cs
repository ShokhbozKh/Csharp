using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public class Displaying
    {
        public Displaying()
        {
            Displayingclassattributes = new HashSet<DisplayingClassAttribute>();
            DisplayingRides = new HashSet<DisplayingRide>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int IdDisplaying { get; set; }
        [Display(Name = "Regular price")]
        [Required]
        [DataType(DataType.Currency)]
        [Column (TypeName = "decimal(18, 2)")]
        public decimal StandardPrice { get; set; }
        [Display (Name = "Departure time")]
        [Required]
        [DataType (DataType.DateTime)]
        public DateTime DepartureTime { get; set; }
        [Display(Name = "Arrival time")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }
        [Display (Name = "Departed")]
        public bool IsDeparted { get; set; }
        public int BusId { get; set; }
        public int SeatId { get; set; }

        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }
        public virtual ICollection<DisplayingClassAttribute> Displayingclassattributes { get; set; }
        public virtual ICollection<DisplayingRide> DisplayingRides { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
