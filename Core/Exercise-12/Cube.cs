using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_12
{
    class Cube
    {
        private Square square;

        public Cube(Square square)
        {
            this.square = square;

            ShowArea();
        }

        public void ShowArea() => Console.WriteLine($"Area: [{square.GetArea() * 6}]");
    }
}
