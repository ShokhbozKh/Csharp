using System;

namespace Exercise_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), el => Convert.ToInt32(el));

            int currentSequense = 1;
            int maxSequense = 0;
            int previousNumber = numbers[0];
            int maxNumber = numbers[0];

            for(int i = 1; i < numbers.Length; i++)
            {
                if(previousNumber == numbers[i])
                {
                    currentSequense++;
                    if(currentSequense > maxSequense)
                    {
                        maxSequense = currentSequense;
                        maxNumber = numbers[i];
                    }
                }
                else
                {
                    currentSequense = 1;
                }

                previousNumber = numbers[i];
            }

            Console.WriteLine($"Longest sequence: {maxSequense} times {maxNumber}");
        }
    }
}
