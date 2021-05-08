using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise_07.Models
{
    [Table("apbd.Student")]
    public partial class Student
    {
        [Key]
        public int IdStudent { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(6)]
        public string IndexNumber { get; set; }

        public int IdStudies { get; set; }

        [ForeignKey("IdStudies")]
        public virtual Study Study { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}