using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject05.Models
{
    class SaleAgreement : Agreement
    {
        public int CarForSaleId { get; set; }
        [ForeignKey("CarForSaleId")]
        public CarForSale CarForSale { get; set; }
    }
}
