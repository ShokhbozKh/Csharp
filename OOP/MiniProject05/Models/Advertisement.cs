using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject05.Models
{
    [Table("Advertisement")]
    class Advertisement
    {
        [Key]
        public int IdAdvertisement { get; set; }
        public string Photo { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
    }
}
