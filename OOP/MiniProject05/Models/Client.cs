using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniProject05.Models
{
    class Client
    {
        [Key]
        public int IdClient { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Discount { get; set; }

        public bool IsRefered { get; set; }

        public int ReferedById { get; set; }
        [ForeignKey("ReferedById")]
        public Client ReferedBy { get; set; }

        public bool IsReferer { get; set; }
        public ICollection<Client> References { get; set; }

        public ICollection<SaleAgreement> SaleAgreements { get; set; }
        public ICollection<RentAgreement> RentAgreements { get; set; }
    }
}
