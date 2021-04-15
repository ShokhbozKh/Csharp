using System;
using System.ComponentModel.DataAnnotations;

namespace DeansOffice.Models.ViewModels
{
    public class EnrollmentViewModel
    {
        [Display(Name = "Code")]
        public int CourseId { get; set; }
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        [Display(Name = "Enrollment date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
    }
}
