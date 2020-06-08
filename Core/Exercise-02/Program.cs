using static System.Console;

namespace Exercise_02
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("Please, start entering your number or 0 to stop");
                var tuple = StartApp();
                WriteLine($"Maximum sequence of numbers is: {tuple.Item1}");
                WriteLine($"The number with maximum sequence is {tuple.Item2}");
                WriteLine($"Please, enter <<go>> to continue or <<exit>> to quit the application");
                string cmd = ReadLine();
                if(cmd == "go")
                {
                    continue;
                }else if(cmd == "exit")
                {
                    WriteLine("The application was stopped");
                    break;
                }else
                {
                    continue;
                }
            }
        }

        static (int, int) StartApp()
        {
            int currentCount = 1, currentNumber = 0,
            previousNumber = 0, maxCount = 0, maxNumber = 0;

            while (true)
            {
                if (int.TryParse(ReadLine(), out int number))
                {
                    currentNumber = number;
                    if (currentNumber == 0)
                    {
                        break;
                    }
                    else
                    {
                        if (currentNumber == previousNumber)
                        {
                            currentCount++;

                            if (currentCount > maxCount)
                            {
                                maxCount = currentCount;
                                maxNumber = currentNumber;
                            }
                        }
                        else
                        {
                            currentCount = 1;
                        }
                    }
                }
                previousNumber = currentNumber;
            }

            return (maxNumber, maxCount);
        }
    }
}
