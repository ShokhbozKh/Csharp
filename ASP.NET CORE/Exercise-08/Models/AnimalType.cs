using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_08.Models
{
    [Table("Animal_Type")]
    public class AnimalType
    {
        [Key]
        public int IdAnimalType { get; set; }
        public string Name { get; set; }
    }
}
