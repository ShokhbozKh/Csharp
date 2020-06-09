using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Models
{
    public enum Type
    {
        Income,
        Expense
    }

    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public Type CategoryType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
