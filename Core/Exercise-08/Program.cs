using static System.Console;

namespace Exercise_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Square[] sqs = {new Square(2), new Square(1),
                            new Square(3), new Square(2)};

            foreach (Square s in sqs)
            {
                Write($"{s} ");
            }

            Write("\nAreas: ");

            foreach(Square s in sqs)
            {
                Write($"{s.GetArea()} ");
            }

            Write("\nPerimeters: ");

            foreach(Square s in sqs)
            {
                Write($"{s.GetPerimeter()} ");
            }

            Circle[] crs = {new Circle(2), new Circle(1),
                            new Circle(3), new Circle(2)};

            Square[] squares = Circle.GetSquares(crs);

            WriteLine("\nPerimeters of squares from circles: ");

            foreach(Square s in squares)
                Write(s.GetArea() + " ");
        }
    }
}
