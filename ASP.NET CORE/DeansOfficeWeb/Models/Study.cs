using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeansOfficeWeb.Models
{
    public class Study
    {
        [Key]
        public int IdStudy { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Study")]
        public string Name { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Yearly price")]
        public decimal Price { get; set; }

        [Range(1, 4)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Study duration")]
        public decimal Duration { get; set; }

        public IEnumerable<Subject> subjects;

        public override string ToString()
        {
            return Name;
        }
    }
}
