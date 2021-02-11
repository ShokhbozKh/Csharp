using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class TicketClassAttribute
    {
        [Key]
        public int IdTicketClassAttribute { get; set; }
        public decimal StandardPrice { get; set; }
        public double DiscountRate { get; set; }
    }
}
