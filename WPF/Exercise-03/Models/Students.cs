using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_04.Models
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public bool Gender { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
