using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public class DisplayingClassAttribute
    {
        public DisplayingClassAttribute()
        {
            Displayings = new HashSet<Displaying>();
        }

        [Key]
        public int IdDisplayingClassAttribute { get; set; }
        [Required]
        [DataType (DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxPrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountRate { get; set; }

        public virtual ICollection<Displaying> Displayings { get; set; }
    }
}
