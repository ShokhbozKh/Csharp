﻿using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Bus
    {
        [Key]
        public int IdBus { get; set; }
        public string BusName { get; set; }
        public int SeatCount { get; set; }
        public bool HasWifi { get; set; }
        public bool HasAirCondition { get; set; }
        public  virtual int BusTypeId { get; set; }
        public int DriverId { get; set; }

        [EnumDataType(typeof(BusType))]
        public BusType BusType { get; set; }
        public Driver Driver { get; set; }
    }
}
