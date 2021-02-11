using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Employee : User
    {
        public DateTime HireDate { get; set; }
        public decimal Discount { get; set; }

        public override void BookTicket()
        {
            throw new NotImplementedException();
        }
    }
}
