namespace MiniProject03.multi
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public Item(int idItem, string make, string model, decimal price)
        {
            IdItem = idItem;
            Make = make;
            Model = model;
            Price = price;
        }
    }
}