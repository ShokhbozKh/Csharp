using System;
using System.Collections.Generic;

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
        public DateTime EnrollmentDate { get; set; }
        public string StudentNumber { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
