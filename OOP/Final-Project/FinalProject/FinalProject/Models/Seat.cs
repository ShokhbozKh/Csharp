using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Seat
    {
        [Key]
        public int IdSeat { get; set; }
        [Required]
        public int Column { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public bool IsAtWindow { get; set; }
    }
}
