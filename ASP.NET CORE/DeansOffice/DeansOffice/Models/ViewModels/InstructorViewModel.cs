using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeansOffice.Models.ViewModels
{
    public class InstructorViewModel
    {
        public int InstructorId { get; set; }
        [MaxLength(150)]
        [Required (ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "First name is required")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }

        [Display(Name = "Course assignments")]
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        [Display(Name = "Office assignment")]
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
