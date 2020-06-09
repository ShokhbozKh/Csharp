using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManagement.Models
{
    public class Item
    {
        [Required]
        [DataType(DataType.Date)]
        [Display (Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Комментарий")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Сумма")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSum { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
