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
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
    }
}
