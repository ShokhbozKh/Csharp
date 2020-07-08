using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public partial class BusTypeDict
    {
        public BusTypeDict()
        {
            Buses = new HashSet<Bus>();
        }

        [Key]
        public int IdBusType { get; set; }
        [Display (Name = "Bus type")]
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public virtual ICollection<Bus> Buses { get; set; }
    }
}
