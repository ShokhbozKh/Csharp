using System.ComponentModel.DataAnnotations;

namespace Assignment_05.Models
{
    public class Income : Item
    {
        [Key]
        public int IdIncome { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
