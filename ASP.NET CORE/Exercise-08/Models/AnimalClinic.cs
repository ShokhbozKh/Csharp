using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_08.Models
{
    public class AnimalClinic
    {
        public int IdAnimalClinic { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdOwner { get; set; }
        public Owner Owner { get; set; }
    }
}
