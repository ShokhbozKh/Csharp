using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text;

namespace Exercise_08
{
    class Circle
    {
        double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public Circle(Square square)
        {
            this.radius = Math.Sqrt(square.GetArea()) / Math.PI;
        }

        public double GetRadius()
        {
            return this.radius;
        }

        public double GetPerimeter()
        {
            return Math.PI * 2 * this.radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }

        public override string ToString()
        {
            return $"Circle[{this.radius:0.0}]";
        }

        public Square GetInscribedSquare()
        {
            return new Square(this.radius * Math.Sqrt(2));
        }

        public Square GetCircumscribedCircle()
        {
            return new Square(this.radius);
        }

        public static Square[] GetSquares(Circle[] arr)
        {
            Square[] squares = new Square[arr.Length];

            for(int i = 0; i < squares.Length; i++)
                squares[i] = new Square(arr[i]);

            return squares;
        }
    }
}
