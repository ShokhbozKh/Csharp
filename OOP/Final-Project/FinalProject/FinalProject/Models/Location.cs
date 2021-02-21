using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Location
    {
        [Key]
        public int IdLocation { get; set; }
        [Required]
        public string LocationName { get; set; }
        public string StationName { get; set; }

        public override string ToString()
        {
            return $"{LocationName}, {StationName}";
        }
    }
}
