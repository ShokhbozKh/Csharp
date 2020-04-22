using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeansOfficeWeb.Models.SchoolViewModels
{
    public class AssignedCourseData
    {
        public int SubjectId { get; set; }
        [Display (Name = "Choose Course")]
        public string SubjectName { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
