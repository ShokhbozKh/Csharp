using System;
using System.Collections.Generic;

namespace DeansOffice.Models
{
    public class Instructor
    {
        public Instructor()
        {
            CourseAssignments = new List<CourseAssignment>();
        }

        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName 
        {
            get => $"{FirstName} {LastName}";
        }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
