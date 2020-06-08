using static System.Console;

namespace Exercise_06
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in new string[] { "A1", "d5", "g6", "c8" })
                WriteLine($"{s} -> {KnightMoves(s)}");
            
        }

        static string KnightMoves(string pos)
        {
            string result = "";
            string position = pos.Substring(0, 1).ToLower() + pos.Substring(1, pos.Length-1);

            string[][] desk = new string[][]{
                new string[] {"a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8" },
                new string[] { "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8" },
                new string[] { "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8" },
                new string[] { "d1", "d2", "d3", "d4", "d5", "d6", "d7", "d8" },
                new string[] { "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8" },
                new string[] { "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8" },
                new string[] { "g1", "g2", "g3", "g4", "g5", "g6", "g7", "g8" },
                new string[] {"h1", "h2", "h3", "h4", "h5", "h6", "h7", "h8" }
            };

            
            for (int i = 0; i < desk.Length; i++)
            {
                for (int j = 0; j < desk[i].Length; j++)
                {
                    if(desk[i][j] == position)
                    {
                        if(i-2 >= 0 && j-1 >= 0)
                        {
                            result += " " + desk[i - 2][j - 1];
                        }
                        if(i-2 >= 0 && j+1 <= 7)
                        {
                            result += " " + desk[i - 2][j + 1];
                        }
                        if(i-1 >= 0 && j-2 >= 0)
                        {
                            result += " " + desk[i - 1][j - 2];
                        }
                        if (i - 1 >= 0 && j + 2 <= 7)
                        {
                            result += " " + desk[i - 1][j + 2];
                        }
                        if(i+2 <= 7 && j-1 >= 0)
                        {
                            result += " " + desk[i + 2][j - 1];
                        }
                        if(i+2 <= 7 && j+1 <= 7)
                        {
                            result += " " + desk[i + 2][j + 1];
                        }
                        if(i+1 <= 7 && j-2 >= 0)
                        {
                            result += " " + desk[i + 1][j - 2];
                        }
                        if(i+1 <= 7 && j+2 <= 7)
                        {
                            result += " " + desk[i + 1][j + 2];
                        }
                    }
                }
            }

            return result;
        }
    }
}
 