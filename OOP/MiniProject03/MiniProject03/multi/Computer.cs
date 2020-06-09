namespace MiniProject03.multi
{
    public class Computer : Item, IComputer
    {
        public string Processor { get; set; }
        public string GPU { get; set; }
        public int RAM { get; set; }

        public Computer(int idItem, string make, string model, decimal price, string processor, string gpu, int ram) :
            base(idItem, make, model, price)
        {
            Processor = processor;
            GPU = gpu;
            RAM = ram;
        }
    }
}