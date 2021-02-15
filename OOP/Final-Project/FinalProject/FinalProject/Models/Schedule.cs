using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Schedule
    {
        [Key]
        public int IdRideSchedule { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Departure time")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime DepartureTime { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Arrival time")]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime ArrivalTime { get; set; }
    }
}
