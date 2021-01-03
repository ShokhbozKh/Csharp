using System.ComponentModel.DataAnnotations;

namespace Assignment_05.Models
{
    public class Expense : Item
    {
        [Key]
        public int IdExpense { get; set; }

        public int MaxMonthlyAmount { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
