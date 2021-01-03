using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_05.Models
{
    public enum ItemType
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

        public ItemType CategoryType { get; set; }
        public List<Item> Items { get; } = new List<Item>();

        public override string ToString()
        {
            return Name;
        }
    }
}
