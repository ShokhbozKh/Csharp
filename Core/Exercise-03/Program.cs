using static System.Console;

namespace Exercise_03
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("Please, enter your first and lastname");
                StartApp(ReadLine());
                if (GetInput())
                {
                    continue;
                }else
                {
                    break;
                }
            }
        }

        static void StartApp(string str)
        {
            int index = str.IndexOf(" ");

            string firstName = str.Substring(0, index);
            string lastName = str.Substring(index);
            int totalLength = firstName.Length + lastName.Length;

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < (totalLength + 11); j++)
                {
                    if(i == 0 || i == 4 || j == 0 || j == firstName.Length + 5 || j == totalLength + 10)
                    {
                        Write("*");
                    }
                    else if(i == 2)
                    {
                        if(j > 2 && j < firstName.Length + 3)
                        {
                            Write(firstName[j - 3]);
                        }
                        else if(j > firstName.Length + 8 && j < totalLength + 8)
                        {
                            Write(lastName[j - (firstName.Length + 8)]);
                        }else
                        {
                            Write(" ");
                        }
                    }
                    else
                    {
                        Write(" ");
                    }
                }
                WriteLine();
            }
        }

        static bool GetInput()
        {
            M: WriteLine("Please, enter <<go>> to continue or <<exit>> to quit the application");

            string result = ReadLine();

            if (result == "go")
            {
                return true;
            } else if (result == "exit")
            {
                return false;
            }else
            {
                goto M;
            }
        }
    }
}
