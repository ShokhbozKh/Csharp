using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Final.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCustomerTypeDicts = new HashSet<CustomerCustomerTypeDict>();
        }

        public int UserId { get; set; }
        [Display (Name = "Date of birth")]
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Display (Name = "Phone number")]
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display (Name = "Discount")]
        [DataType(DataType.Currency)]
        [Column (TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<CustomerCustomerTypeDict> CustomerCustomerTypeDicts { get; set; }

    }
}
