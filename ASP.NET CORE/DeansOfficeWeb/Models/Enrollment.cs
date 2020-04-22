using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeansOfficeWeb.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        [Key]
        public int IdEnrollment { get; set; }

        [Display(Name = "Grade")]
        public Grade? Grade { get; set; }

        [Required, MaxLength(100)]
        public string SubjectType { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [ForeignKey("IdSubject")]
        public Subject Subject { get; set; }

        public int IdSubject { get; set; }

        [ForeignKey("IdStudent")]
        public Student Student { get; set; }

        public int IdStudent { get; set; }

        [ForeignKey("IdInstructor")]
        public Instructor Instructor { get; set; }

        public int IdInstructor { get; set; }
    }
}
