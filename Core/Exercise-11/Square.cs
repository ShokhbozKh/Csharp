using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Exercise_11
{
    class Square
    {
        private double side;

        public Square(double side) => this.side = side;

        public double GetSide() => side;

        public double GetArea() => Math.Pow(side, 2);

        public double GetDiagonal() => Math.Sqrt(Math.Pow(side, 2) + Math.Pow(side, 2));

        public double GetPerimeter() => 4 * side;
    }
}
