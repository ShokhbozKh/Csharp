using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice.Models
{
    public partial class Student
    {
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public string Status { get; set; }
        public int Year { get; set; }
        public string Semester { get; set; }
        public string Specialization { get; set; }
        public string Information { get; set; }

    }
}
