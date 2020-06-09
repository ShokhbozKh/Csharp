using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManagement.Models
{
    public class History
    {
        [Key]
        public int IdHistory { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DeletedDate { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Комментарий")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Сумма")]
        public decimal TotalSum { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string ItemType { get; set; }
    }
}
