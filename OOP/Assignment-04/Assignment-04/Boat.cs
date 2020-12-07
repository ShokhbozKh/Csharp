using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_04
{
    class Boat : IBoat
    {
        public Guid IdBoat { get; private set; }
        public decimal Price { get; private set; } // per km
        public double Engine { get; set; }
        public double WaterDispacement { get; set; }

        public Boat(decimal price, double engine, double waterDispacement)
        {
            IdBoat = Guid.NewGuid();
            Price = price;
            Engine = engine;
            WaterDispacement = waterDispacement;
        }

        public double CalculateSpeed()
        {
            // There should be some appropriate method to calculate
            // the speed using different aspects of the properties of Boat
            // for the sake of implementation and simplicity I will use
            // random calculation

            return WaterDispacement *
                (Math.MaxMagnitude(Engine, WaterDispacement) / Math.Cos(WaterDispacement));
        }
    }
}