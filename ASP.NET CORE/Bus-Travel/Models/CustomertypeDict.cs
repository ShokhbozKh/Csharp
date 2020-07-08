using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAS_Final.Models
{
    public class CustomertypeDict
    {
        public CustomertypeDict()
        {
            CustomerCustomerTypeDicts = new HashSet<CustomerCustomerTypeDict>();
        }

        [Key]
        public int IdCustomerType { get; set; }
        [Display (Name = "Type of the customer")]
        [Required, MaxLength(150)]
        public string CustomerTypeTitle { get; set; }

        public virtual ICollection<CustomerCustomerTypeDict> CustomerCustomerTypeDicts { get; set; }
    }
}
