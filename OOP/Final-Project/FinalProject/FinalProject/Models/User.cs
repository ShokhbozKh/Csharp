using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    [Table("Users")]
    public abstract class User
    {
        public User()
        {
            PromoCode = Guid.NewGuid();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Login { get; set; }
        [Required]
        [MaxLength(150)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [NotMapped]
        public Guid PromoCode { get; set; }

        public abstract void BookTicket();
    }
}
