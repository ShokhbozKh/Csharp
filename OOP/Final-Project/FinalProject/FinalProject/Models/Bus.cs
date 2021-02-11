using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Bus
    {
        [Key]
        public int IdBus { get; set; }
        [Required]
        [StringLength(50)]
        public string BusName { get; set; }
        public int? SeatCount { get; set; }
        [Required]
        public bool HasWifi { get; set; }
        [Required]
        public bool HasAirCondition { get; set; }

        public  int BusTypeId { get; set; }
        public int DriverId { get; set; }

        [EnumDataType(typeof(BusType))]
        public BusType BusType { get; set; }
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }
    }
}
