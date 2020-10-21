using System;
using System.Linq;
using System.Xml.XPath;

namespace Exercise_06
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string position in new string[] { "A1","d5","g6","C8"})
                Console.WriteLine($"{position} -> {KnightMoves(position)}");
        }

        static string KnightMoves(string position)
        {
            string[][] chessDesk = new string[][]
            {
                new string[] {"a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1"},
                new string[] {"a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2"},
                new string[] {"a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3"},
                new string[] {"a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4"},
                new string[] {"a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5"},
                new string[] {"a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6"},
                new string[] {"a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7"},
                new string[] {"a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8"}
            };

            string result = "";



            for(int i = 0; i < chessDesk.Length; i++)
            {
                for(int j = 0; j < chessDesk[i].Length; j++)
                {
                    if (chessDesk[i][j].Equals(position.ToLower()))
                    {
                        // Check left and right possible moves
                        if (j - 2 >= 0 && i - 1 >= 0)
                            result += chessDesk[i - 1][j - 2] + " ";
                        if (j - 2 >= 0 && i + 1 <= 7)
                            result += chessDesk[i + 1][j - 2] + " ";
                        if (j + 2 <= 7 && i - 1 >= 0)
                            result += chessDesk[i - 1][j + 2] + " ";
                        if (j + 2 <= 7 && i + 1 <= 7)
                            result += chessDesk[i + 1][j + 2] + " ";
                        
                        // Check top and bottom possible moves
                        if (i - 2 >= 0 && j - 1 >= 0)
                            result += chessDesk[i - 2][j - 1] + " ";
                        if (i - 2 >= 0 && j + 1 <= 7)
                            result += chessDesk[i - 2][j + 1] + " ";
                        if (i + 2 <= 7 && j - 1 >= 0)
                            result += chessDesk[i + 2][j - 1] + " ";
                        if (i + 2 <= 7 && j + 1 <= 7)
                            result += chessDesk[i + 2][j + 1] + " ";
                    }
                }
            }

            return result;
        }
    }
}
