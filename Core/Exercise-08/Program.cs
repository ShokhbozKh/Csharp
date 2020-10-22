using System;

namespace Exercise_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Square[] sqs = new Square[]
            {
                new Square(2), new Square(1),
                new Square(3), new Square(2)
            };

            foreach (Square square in sqs)
                Console.Write($"{square} ");

            Console.Write("\n Areas:");
            foreach (Square square in sqs)
                Console.Write($"{square.GetArea():0.0} ");

            Console.Write("\n Perimeteres: ");
            foreach (Square square in sqs)
                Console.Write($"{square.GetPerimeter():0.0} ");

            Circle[] crs = new Circle[]
            {
                new Circle(2), new Circle(1),
                new Circle(3), new Circle(2)
            };

            Square[] squares = Circle.GetSquares(crs);

            Console.Write("\n Perimeters of squares from circles: ");
            foreach (Square square in squares)
                Console.Write($"{square.GetArea():0.00} ");
            Console.WriteLine();
        }
    }
}
