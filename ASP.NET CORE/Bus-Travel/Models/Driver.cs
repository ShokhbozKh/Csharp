using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public class Driver
    {
        [Key]
        public int IdDriver { get; set; }
        [Display (Name = "Driver name")]
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Display (Name = "Driver last name")]
        [Required, MaxLength(15)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

    }
}
