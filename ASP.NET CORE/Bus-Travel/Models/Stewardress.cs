using System.ComponentModel.DataAnnotations;

namespace MAS_Final.Models
{
    public partial class Stewardress
    {
        [Key]
        public int IdStewardress { get; set; }
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        public string LastName { get; set; }

    }
}
