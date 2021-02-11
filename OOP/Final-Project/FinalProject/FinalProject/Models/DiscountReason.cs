using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class DiscountReason
    {
        [Key]
        public int IdDiscountReason { get; set; }
        [Required]
        [MaxLength(150)]
        public string DiscountName { get; set; }

    }
}
