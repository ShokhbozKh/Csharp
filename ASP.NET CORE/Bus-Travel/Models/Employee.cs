using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public partial class Employee
    {
        public int UserId { get; set; }
        [Display (Name = "Employee name")]
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Display (Name = "Employee last name")]
        [Required, MaxLength(150)]
        public string LastName { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
