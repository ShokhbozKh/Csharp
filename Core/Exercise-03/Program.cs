using System;
using System.Dynamic;

namespace Exercise_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your first input");
            string firstInput = Console.ReadLine();
            Console.WriteLine("Enter your first input");
            string secondInput = Console.ReadLine();

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < firstInput.Length + secondInput.Length + 11; j++)
                {
                    // If it is first or last line, print only stars
                    if (i == 0 || i == 4)
                    {
                        Console.Write("*");
                    }
                    // If it is middle line, print input strings
                    else if (i == 2)
                    {
                        // If it is beginning or middle or end of the line, print star
                        if (j == 0 || j == firstInput.Length + 5 || j == firstInput.Length + secondInput.Length + 10)
                            Console.Write("*");
                        // If it is the position after printing star + spaces, print first input
                        else if (j == 3)
                            Console.Write(firstInput);
                        // If it is the position after printing star + spaces + first input + star + 2 spaces,
                        // then print second input
                        else if (j == firstInput.Length + 8)
                            Console.Write(secondInput);
                        // Print beginning spaces
                        else if (j < 3)
                            Console.Write(" ");
                        // Print spaces after first input
                        else if(j > firstInput.Length + 2 && j < firstInput.Length + 5)
                            Console.Write(" ");
                        // Print spaces after first input and middle star
                        else if(j > firstInput.Length + 5 && j < firstInput.Length + 8)
                            Console.Write(" ");
                        // Print spaces after first input + second input
                        else if(j > firstInput.Length + secondInput.Length + 7)
                            Console.Write(" ");
                    } 
                    // In other lines, at first and last positions print stars
                    else if (j == 0 || j == firstInput.Length + secondInput.Length + 10 || j == firstInput.Length + 5)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                
                // Indent one line
                Console.WriteLine();
            }
        }
    }
}
