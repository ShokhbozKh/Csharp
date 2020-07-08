using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MAS_Final.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int IdUser { get; set; }
        [Required, MaxLength(150)]
        public string Login { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [MaxLength(150)]
        public string LastName { get; set; }
        public int IdUserRole { get; set; }

        public virtual UserRoleDict IdUserRoleNavigation { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
