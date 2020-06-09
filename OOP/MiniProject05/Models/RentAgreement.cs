using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject05.Models
{
    class RentAgreement : Agreement
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CarForRentId { get; set; }
        [ForeignKey("CarForRentId")]
        public CarForRent CarForRent { get; set; }
    }
}
