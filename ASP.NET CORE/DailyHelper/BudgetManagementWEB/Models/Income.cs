using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Models
{
    public class Income : Item
    {
        [Key]
        public int IdIncome { get; set; }
    }
}
