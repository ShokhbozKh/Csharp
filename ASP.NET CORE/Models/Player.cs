using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_10.Models
{
    public class Player
    {
        [Key]
        public int IdPlayer { get; set; }
        [Required, MaxLength(150)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Birthdate")]
        public string BirthDate { get; set; }
        [Display(Name = "Team")]
        public int IdTeam { get; set; }
        [ForeignKey("IdTeam")]
        public Team Team { get; set; }  

    }
}
