using System.ComponentModel.DataAnnotations;

namespace MiniProject05.Models
{
    class ClassAttributes
    {
        [Key]
        public int IdClassAttribute { get; set; }
        public decimal AgentCommision { get; set; }
    }
}
