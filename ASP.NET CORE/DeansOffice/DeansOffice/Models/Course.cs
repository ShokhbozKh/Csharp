using System.Collections.Generic;

namespace DeansOffice.Models
{
    public class Course
    {
        public Course()
        {
            Enrollments = new List<Enrollment>();
            CourseAssignments = new List<CourseAssignment>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public string CourseCode { get; set; }
        public int Credits { get; set; }
        public decimal Price { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

    }
}
