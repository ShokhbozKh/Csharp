using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [EnumDataType(typeof(BusType))]
        public BusType BusType { get; set; }
    }
}
