using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject05.Models
{
    class Agreement
    {
        [Key]
        public int IdAgreement { get; set; }
        public DateTime SignDate { get; set; }
        public decimal AgencyCommision { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        [ForeignKey("AgentId")]
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}
