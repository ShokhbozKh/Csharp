using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeansOffice.Models
{
    public class Student
    {
        public Student()
        {
            Enrollments = new List<Enrollment>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
