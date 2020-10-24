using System;

namespace Exercise_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 2, 3, 2, 4, 3, 1, 6, 3, 2, 3 };

            Console.WriteLine($"# of Even: {CountEven(a,0)}");
        }

        static int CountEven(int[] arr, int from)
        {
            if (from == arr.Length) return 0;

            int result;
            if (arr[from] % 2 == 0)
                result = 1;
            else
                result = 0;

            return result + CountEven(arr, ++from);
        }
    }
}
