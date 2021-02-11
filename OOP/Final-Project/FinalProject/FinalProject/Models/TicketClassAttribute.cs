using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class TicketClassAttribute
    {
        [Key]
        public int IdTicketClassAttribute { get; set; }
        [Range(1, 1500)]
        [DataType(DataType.Currency)]
        public decimal StandardPrice { get; set; }
        public double? DiscountRate { get; set; }
    }
}
