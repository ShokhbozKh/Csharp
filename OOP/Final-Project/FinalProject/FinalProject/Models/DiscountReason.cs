using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class DiscountReason
    {
        [Key]
        public int IdDiscountReason { get; set; }
        public string DiscountName { get; set; }

    }
}
