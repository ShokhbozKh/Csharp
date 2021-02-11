using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Location
    {
        [Key]
        public int IdLocation { get; set; }
        public string LocationName { get; set; }
    }
}
