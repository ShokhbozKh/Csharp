using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_08.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string AnimalName { get; set; }
        public int? Age { get; set; }
        [ForeignKey("Owner")]
        public int IdOwner { get; set; }
        public Owner Owner { get; set; } // --> shadow property


    }
}
