using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public abstract class User
    {
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


        public abstract void BookTicket();
    }
}
