using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Displaying
    {
        [Key]
        public int IdDisplaying { get; set; }
        [Required]
        public decimal StandardPrice { get; set; }
        public int? AvialableSeats { get; set; }
        [Required]
        public bool IsDeparted { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; set; }

        public int RideId { get; set; }
        public int BusId { get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }
        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
    }
}
