using System;

namespace MiniProject03
{
    public abstract class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int Horsepower { get; set; }

        public int TankCapacityLiters { get; set; }
        public int BatteryCapacityMah { get; set; }
    }
}