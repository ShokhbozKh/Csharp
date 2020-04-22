using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_10.Models
{
    public class Team
    {
        [Key]
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
