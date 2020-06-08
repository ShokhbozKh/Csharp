using static System.Console;

namespace Exericse_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 3, 6, 7, 6, 8, 2, 9 };
            int[] brr = { 2, 3, 6, 8, 5, 1 };

            PrintResult(arr, brr);
        }

        static void PrintResult(int[] arr, int[] brr)
        {
            bool exists = false;
            for(int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(arr[i] == arr[j])
                    {
                        exists = true;
                        break;
                    }else
                    {
                        exists = false;
                    }
                }
                if (!exists)
                {
                    for (int k = 0; k < brr.Length; k++)
                    {
                        if (arr[i] == brr[k])
                        {
                            Write(arr[i] + " ");
                        }
                    }
                }
               
            }
        }
    }
}
