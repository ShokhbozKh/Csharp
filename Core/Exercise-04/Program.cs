using System;

namespace Exercise_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 3, 6, 7, 6, 8, 2, 9 };
            int[] arr1 = { 2, 3, 6, 8, 5, 1 };

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr1.Length; j++)
                {
                    if(arr[i] == arr1[j])
                    {
                        bool occured = false;
                        for(int k = i-1; k >= 0; k--)
                        {
                            if (arr[i] == arr[k])
                            {
                                occured = true;
                                break;
                            }   
                        }

                        if (!occured)
                        {
                            Console.Write($"{arr[i]} ");
                        }
                    }
                }
            }
        }
    }
}
