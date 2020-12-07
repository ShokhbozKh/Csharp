using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_04
{
    class Amphicar : Car, IBoat
    {
        public double Engine { get; set; }
        public double WaterDispacement { get; set; }

        public Amphicar(string amphicarNumber, string brand, decimal price, Category category,
            double engine, double waterDispacement)
            : base(amphicarNumber, brand, price, category)
        {
            Engine = engine;
            WaterDispacement = waterDispacement;
        }

        public double GetSpeed()
        {
            // There should be some appropriate method to calculate
            // the speed using different aspects of the properties of Boat
            // for the sake of implementation and simplicity I will use
            // random calculation

            return WaterDispacement *
                (Math.MaxMagnitude(Engine, WaterDispacement) / Math.Cos(WaterDispacement));
        }

        double IBoat.CalculateSpeed()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
