using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeansOffice.Models
{
    public class Department
    {
        public Department()
        {
            Courses = new List<Course>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }

        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
