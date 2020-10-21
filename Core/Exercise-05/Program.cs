using System;
using System.Reflection.PortableExecutable;

namespace Exercise_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr =
            {
                new int[] {1,2,3,4,5,6},
                new int[] {2,3,4,5,6,7},
                new int[] {3,4,5,6,7,8},
                new int[] {4,5,6,7,8,9},
                new int[] {5,6,7,8,9,10}
            };
            Inner(arr);
            
            foreach (int[] subArray in Inner(arr))
            {
                foreach (int el in subArray)
                    Console.Write($"{el} ");

                Console.WriteLine();
            }
        }

        static int[][] Inner(int[][] arr)
        {
            int[][] result = new int[arr.Length-2][];

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = new int[arr[i].Length - 2];
                for(int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = arr[i + 1][j + 1];
                }
            }

            return result;
        }
    }
}
