using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniProject05.Models
{
    class Agent
    {
        [Key]
        public int IdAgent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ClassAttributes ClassAttributes { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<RentAgreement> rentAgreements { get; set; }
        public ICollection<SaleAgreement> SaleAgreements { get; set; }
    }
}
