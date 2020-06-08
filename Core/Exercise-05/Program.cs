using static System.Console;
using System;

namespace Exercise_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[][]
            {
                new int[] {1, 2, 3, 4, 5, 6 },
                new int[] {2, 3, 4, 5, 6, 7 },
                new int[] {3, 4, 5, 6, 7, 8 },
                new int[] {4, 5, 6, 7, 8, 9 }
            };

            foreach (int[] r in a)
            {
                foreach (int s in r)
                    Write(s + " ");
                WriteLine();
            }
                
            WriteLine();

            foreach (int[] r in Inner(a))
            {
                foreach (int s in r)
                {
                    Write(s + " ");
                }
                WriteLine();
            }
                
        }

        static int[][] Inner(int[][] arr)
        {
            int[][] result = new int[arr.Length-2][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[arr[i].Length - 2];
            }

            for(int i = 1; i < arr.Length - 1; i++)
            {
                for(int j = 1; j < arr[i].Length - 1; j++)
                {
                    result[i-1][j-1] = arr[i][j];
                }
            }

            return result;
        }
    }
}
