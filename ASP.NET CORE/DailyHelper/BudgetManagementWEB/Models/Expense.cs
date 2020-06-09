using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Models
{
    public class Expense : Item
    {
        [Key]
        public int IdExpense { get; set; }
    }
}
