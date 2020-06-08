using static System.Console;

namespace Exercise_01
{
    class Program
    {
        static void Main(string[] args)
        {
            while (RunCalculator())
            {
                WriteLine();
                WriteLine("Enter <<exit>> to quit the application");
            }

            WriteLine("The application is stopped");
        }


        static bool RunCalculator()
        {
            WriteLine("Please, enter your first number");
            decimal fn;
            string operation;

            while (true)
            {
                string input = ReadLine();
                if (input == "exit")
                {
                    return false;
                }


                if(decimal.TryParse(input, out decimal firstNumber))
                {
                    WriteLine("Please, choose operation: + - * / %");
                    fn = firstNumber;
                    break;
                }
                else
                {
                    WriteLine("Please, enter a valid number");
                }
            };

            while (true)
            {
                string op = ReadLine();

                if (op == "+" || op == "-" || op == "*" || op == "/" || op == "%")
                {
                    operation = op;
                    break;
                }
                else
                {
                    WriteLine("Please, choose a valid operation: + - * / %");
                }
            }

            WriteLine("Please, enter you second number");

            while (true)
            {
                if (decimal.TryParse(ReadLine(), out decimal sn))
                {
                    WriteLine($"The result is: {Calculate(fn, sn, operation)}");
                    break;
                }
                else
                {
                    WriteLine("Please, enter a valid number");
                }
            };

            return true;
        }

        static decimal Calculate(decimal fn, decimal sn, string op)
        {
            switch (op)
            {
                case "+":
                    return fn + sn;
                case "-":
                    return fn + sn;
                case "*":
                    return fn * sn;
                case "/":
                    return fn / sn;
                case "%":
                    return fn % sn;
                default:
                    return 0; ;
            }
        }
        
    }
}
