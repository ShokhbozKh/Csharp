using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Driver
    {
        [Key]
        public int IdDriver { get; set; }
        [Required]
        [MaxLength(150)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }
        [Range(1, 5000)]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}
