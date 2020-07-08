using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public partial class Bus
    {
        public Bus()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int IdBus { get; set; }
        [Display (Name = "Bus")]
        [Required, MaxLength(150)]
        public string BusName { get; set; }
        [Display (Name = "Number of seats")]
        [Required]
        public int SeatCount { get; set; }
        [Display (Name = "Number of floors")]
        [Required]
        public int FloorCount { get; set; }
        [Display (Name = "Has internet connection")]
        public bool HasWifi { get; set; }
        [Display (Name = "Has air condition")]
        public bool HasAirCondition { get; set; }
        [Display (Name = "Has electricity")]
        public bool HasCharger { get; set; }
        [Display (Name = "Has buffet")]
        public bool HasBuffet { get; set; }
        public int BusTypeId { get; set; }
        
        [Display(Name = "Bus type")]
        [ForeignKey("BusTypeId")]
        public BusTypeDict BusType { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
