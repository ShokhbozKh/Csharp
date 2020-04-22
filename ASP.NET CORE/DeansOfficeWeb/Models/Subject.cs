using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeansOfficeWeb.Models
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }
        [Required, MaxLength(100)]
        [Display(Name = "Subject Name")]
        public string Name { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Subject price")]
        public decimal Price { get; set; }

        [DataType(DataType.Duration)]
        [Display(Name = "Hours of classes")]
        public int Hours { get; set; }

        [Range(1, 60)]
        [Display(Name = "ECTS")]
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
