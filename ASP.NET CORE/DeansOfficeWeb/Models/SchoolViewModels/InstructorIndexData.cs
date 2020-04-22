using System.Collections.Generic;

namespace DeansOfficeWeb.Models.SchoolViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
