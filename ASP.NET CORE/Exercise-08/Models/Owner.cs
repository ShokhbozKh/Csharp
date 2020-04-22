using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_08.Models
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }

        public ICollection<Animal> Animals { get; set; }
        public ICollection<AnimalClinic> AnimalClinics { get; set; }

    }
}
