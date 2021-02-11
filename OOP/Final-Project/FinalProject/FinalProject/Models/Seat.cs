using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Seat
    {
        [Key]
        public int IdSeat { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsAtWindow { get; set; }
    }
}
