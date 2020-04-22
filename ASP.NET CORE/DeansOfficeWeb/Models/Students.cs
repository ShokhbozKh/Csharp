using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeansOfficeWeb.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [MaxLength(6)]
        [Display(Name = "Student Number")]
        public string IndexNumber { get; set; }

        public int IdStudy { get; set; }

        [ForeignKey("IdStudy")]
        [Display(Name = "Department")]
        public Study Study { get; set; }
    }
}
