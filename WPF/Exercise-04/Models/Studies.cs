using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05.Models
{
    class Studies
    {
        public int IdStudies { get; set; }
        public string StudyName { get; set; }

        public override string ToString()
        {
            return StudyName;
        }
    }
}
