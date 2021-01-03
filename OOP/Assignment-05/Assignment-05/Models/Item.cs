using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_05.Models
{
    public class Item
    {
        [Key]
        public int IdItem { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Comment")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Total sum")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSum { get; set; }
        
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Category")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"Description: [{Description}], Added date: [{AddedDate}] Category: [{Category.Name}]";
        }
    }
}
