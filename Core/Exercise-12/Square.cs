using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_12
{
    class Square
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
            ShowArea();
        }

        public double GetSide() => side;

        public double GetArea() => Math.Pow(side, 2);

        public void ShowArea() => Console.WriteLine($"Area: [{Math.Pow(side, 2)}]");

        public Cube GetCube() => new Cube(this);
    }
}
