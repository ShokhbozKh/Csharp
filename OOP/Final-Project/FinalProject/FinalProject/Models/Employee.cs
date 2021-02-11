using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Employee : User
    {
        [DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Discount { get; set; }

        public override void BookTicket()
        {
            throw new NotImplementedException();
        }
    }
}
