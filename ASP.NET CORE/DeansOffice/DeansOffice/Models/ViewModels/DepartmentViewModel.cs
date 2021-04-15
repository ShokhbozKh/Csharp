using System;

namespace DeansOffice.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public DateTime HireDate { get; set; }
    }
}
