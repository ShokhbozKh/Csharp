using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_05.Models
{
    public class History
    {
        [Key]
        public int IdHistory { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DeletedDate { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Comment")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total Sum")]
        public decimal TotalSum { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string ItemType { get; set; }
    }
}
