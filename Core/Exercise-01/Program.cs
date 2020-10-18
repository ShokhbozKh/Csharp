using System;

namespace Exercise_01
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:

            // Get first input
            Console.WriteLine("Please, insert your first number");

        FirstInput:

            // If incorrect input was entered, perform this operation again.
            if (!Double.TryParse(Console.ReadLine(), out double firstNumber))
            {
                Console.WriteLine("Incorrect number, please, try again.");
                goto FirstInput;
            }
                

            // Get operator
            Console.WriteLine("Please, insert operation you want to perform");
            string operation = Console.ReadLine();

            // Get second input
            Console.WriteLine("Please, insert you second number");

        SecondInput:
            
            // If incorrect input was entered, perform this operation again.
            if(!Double.TryParse(Console.ReadLine(), out double secondNumber))
            {
                Console.WriteLine("Incorrect number, please, try again");
                goto SecondInput;
            }
            

            double result;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "%":
                    result = firstNumber % secondNumber;
                    break;
                // If incorrect operator was entered, go the begininning
                default:
                    Console.WriteLine("Please, insert correct operator");

                    // Indent one line
                    Console.WriteLine();
                    goto Start;
            }

            // Print the result
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {result}");

            // Indent one line
            Console.WriteLine();

            // Ask if user wants to continue
            Console.WriteLine("Do you want to continue? Insert 'yes' to continue or 'no' to quit the application");
            string decision = Console.ReadLine();

            // Indent one line
            Console.WriteLine();

            if(decision.Equals("yes"))
                goto Start;
        }
    }
}
