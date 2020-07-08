using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAS_Final.Models
{
    public class DiscountReasonDict
    {
        public DiscountReasonDict()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int IdDiscountReason { get; set; }
        [Required, MaxLength(150)]
        public string DiscountReasonTitle { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
