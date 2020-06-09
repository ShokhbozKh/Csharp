using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniProject05.Models
{
    class CarForRent : Car
    {
        [DataType(DataType.Currency)]
        public decimal MonthlyCost { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public DateTime AvialableFrom { get; set; }

        public ICollection<RentAgreement> rentAgreements { get; set; }
    }
}
