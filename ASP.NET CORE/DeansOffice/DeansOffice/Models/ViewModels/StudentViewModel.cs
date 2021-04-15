using System;
using System.ComponentModel.DataAnnotations;

namespace DeansOffice.Models.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Display (Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Display (Name = "Full name")]
        public string FullName { get => $"{FirstName} {LastName}"; }
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        [MaxLength(6)]
        [Display(Name = "Student number")]
        public string StudentNumber { get; set; }
    }
}
