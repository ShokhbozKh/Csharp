using System.ComponentModel.DataAnnotations;

namespace MiniProject05.Models
{
    class CarForSale : Car
    {
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal MinPrice { get; set; }
    }
}
