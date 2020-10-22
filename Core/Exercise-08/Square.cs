using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_08
{
    class Square
    {
        double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public Square(Circle circle)
        {
            this.sideLength = Math.Sqrt(circle.GetArea());
        }

        public double GetSide()
        {
            return this.sideLength;
        }

        public double GetPerimeter()
        {
            return 4 * this.sideLength;
        }

        public double GetArea()
        {
            return Math.Pow(this.sideLength, 2);
        }

        public override string ToString()
        {
            return $"Square[{this.sideLength:0.0}]";
        }

        public Circle GetInscribedCircle()
        {
            return new Circle(this.sideLength/2);
        }

        public Circle GetCircumscribedCircle()
        {
            return new Circle(Math.Sqrt(Math.Pow(this.sideLength, 2) + Math.Pow(this.sideLength, 2)));
        }
    }
}
