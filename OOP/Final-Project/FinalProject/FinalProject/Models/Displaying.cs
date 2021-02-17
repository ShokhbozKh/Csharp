﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Displaying
    {
        [Key]
        [ForeignKey("RideSchedule")]
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
        [Required]
        public string BusName { get; set; }


        //public int RideScheduleId { get; set; }
        //public int BusId { get; set; }

        //[ForeignKey("RideScheduleId")]
        public RideSchedule RideSchedule { get; set; }
        /*[ForeignKey("BusId")]
        public Bus Bus { get; set; }*/
    }
}
