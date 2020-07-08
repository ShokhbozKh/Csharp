using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAS_Final.Models
{
    public partial class UserRoleDict
    {
        public UserRoleDict()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int IdUserRole { get; set; }
        [Required, MaxLength(150)]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
