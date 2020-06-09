using System.Collections.Generic;

namespace MiniProject03.multi
{
    public class Smartphone : Cellphone, IComputer
    {
        private readonly Computer _computer;

        public Computer Computer => _computer;

        public Smartphone(int idItem, string make, string model, decimal price, ICollection<int> workingFrequencies
            , string processor, string gpu, int ram) : base(idItem, make, model, price, workingFrequencies)
        {
            _computer = new Computer(0, null, null, 0, processor, gpu, ram);
        }

        public string Processor
        {
            get => _computer.Processor;
            set => _computer.Processor = value;
        }

        public string GPU
        {
            get => _computer.GPU;
            set => _computer.GPU = value;
        }

        public int RAM
        {
            get => _computer.RAM;
            set => _computer.RAM = value;
        }
    }
}