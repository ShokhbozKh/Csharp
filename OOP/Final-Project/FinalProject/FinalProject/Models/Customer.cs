using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    class Customer : User
    {
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public double Discount { get; set; }


        public override void BookTicket()
        {
            throw new NotImplementedException();
        }
    }
}
