using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_08
{
    class Circle
    {
        private double radius;

        public Circle(double radius)
        {
            SetRadius(radius);
        }

        public Circle(Square square)
        {
            this.radius = Math.Sqrt(square.GetArea()) / Math.PI;
        }

        private void SetRadius(double radius)
        {
            this.radius = radius;
        }

        public double GetRadius()
        {
            return this.radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }

        public double GetPerimeter()
        {
            return Math.PI * (this.radius * 2);
        }

        public Square GetInscribedSquare()
        {
            return new Square(this.radius * 2);
        }

        public Square GetCircumScribedSquare()
        {
            return new Square(Math.Sqrt(this.radius*2));
        }

        public static Square[] GetSquares(Circle[] arr)
        {
            Square[] squares = new Square[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                squares[i] = new Square(arr[i]);
            }

            return squares;
        }

        public override string ToString()
        {
            return $"Circle: [{this.radius}]";
        }
    }
}
