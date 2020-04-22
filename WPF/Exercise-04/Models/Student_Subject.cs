using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05.Models
{
    class Student_Subject
    {
        public int IdStudentSubject { get; set; }
        public int IdStudent { get; set; }
        public int IdSubject { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
