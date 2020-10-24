using System;

namespace Exercise_12
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1

            /*Word word = new Word("Hello, ");
            word.SetNextWord(new Word("my "));
            word.SetNextWord(new Word("name "));
            word.SetNextWord(new Word("is "));
            word.SetNextWord(new Word("John"));

            word.Show();*/

            #endregion

            #region Task2

            Square square = new Square(12);
            Cube cube = new Cube(square);

            Square square1 = new Square(6);
            Cube cube1 = square1.GetCube();

            
            #endregion
        }
    }
}
