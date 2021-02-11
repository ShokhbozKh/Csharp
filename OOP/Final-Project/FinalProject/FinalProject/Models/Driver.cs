using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Driver
    {
        [Key]
        public int IdDriver { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
