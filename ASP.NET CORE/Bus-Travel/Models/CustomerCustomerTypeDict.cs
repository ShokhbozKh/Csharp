using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public class CustomerCustomerTypeDict
    {
        [Key]
        public int IdCustomerCustomerTypeDict { get; set; }
        public int CustomerTypeId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Customer Customer { get; set; }
        [ForeignKey("CustomerTypeId")]
        public CustomertypeDict Customertype { get; set; }
    }
}
