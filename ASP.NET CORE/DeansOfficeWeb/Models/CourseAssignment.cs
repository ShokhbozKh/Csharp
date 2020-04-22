using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeansOfficeWeb.Models
{
    public class CourseAssignment
    {
        [Key]
        public int CourseAssignments { get; set; }

        public int InstructorId { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; }

        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        [Display(Name = "Course")]
        public Subject Subject { get; set; }
    }
}
