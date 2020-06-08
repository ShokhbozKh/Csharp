using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_08
{
    class Square
    { 
        private double length;

        public Square(double length)
        {
            SetSide(length);
        }

        public Square(Circle circle)
        {
            this.length = Math.Sqrt(circle.GetArea());
        }

        private void SetSide(double length)
        {
            if(length > 0)
            {
                this.length = length;
            }
        }

        public double GetArea()
        {
            return Math.Pow(this.length, 2);
        }

        public double GetPerimeter()
        {
            return this.length * 4;
        }

        public Circle GetIncribedCircle()
        {
            return new Circle(this.length);
        }

        public Circle GetCircumscribedCircle()
        {
            return new Circle(this.length*(Math.Sqrt(2)));
        }

        public override string ToString()
        {
            return $"Square: [{this.length}]";
        }
    }
}
