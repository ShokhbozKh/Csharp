using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Ride
    {
        [Key]
        public int IdRide { get; set; }
        public Location StartPoint { get; set; }
        public Location DestinationPoint { get; set; }
        public double TotalHours { get; set; }        
    }
}
