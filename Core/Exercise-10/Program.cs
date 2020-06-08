using static System.Console;

namespace Exercise_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Warsaw(){ London[xxxx} ( Madrid Paris)} Berlin";
            string[] arr = file.Split(" ");

            ParenStack parenStack = new ParenStack();

            int errorLine = 0, errorPosition = 0;
            string errorTypes = "";
            Type type;

            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    switch (arr[i][j])
                    {
                        case '{':
                            parenStack.Push(Type.curlyOpen);
                            break;
                        case '(':
                            parenStack.Push(Type.roundOpen);
                            break;
                        case '[':
                            parenStack.Push(Type.squareOpen);
                            break;
                        case '}':
                            type = parenStack.Pop();
                            if(type != Type.curlyOpen)
                            {
                                errorLine = i;
                                errorPosition = j;
                                errorTypes += type.ToString();
                            }
                            break;
                        case ')':
                            type = parenStack.Pop();
                            if (type != Type.roundOpen)
                            {
                                errorLine = i;
                                errorPosition = j;
                                errorTypes += type.ToString();
                            }
                            break;
                        case ']':
                            type = parenStack.Pop();
                            if (type != Type.squareOpen)
                            {
                                errorLine = i;
                                errorPosition = j;
                                errorTypes += type.ToString();
                            }
                            break;
                        default:
                            continue;
                    }
                }

            }

            if(errorPosition > 0)
            {
                for(int i = 0; i < arr.Length; i++)
                {
                    Write(arr[i]);
                    WriteLine();
                    for(int j = 0; j < arr[i].Length; j++)
                    {
                        if(i == errorLine && j == errorPosition)
                        {
                            Write("^");
                        }else
                        {
                            Write(" ");
                        }
                    }
                    WriteLine();
                }
                WriteLine($"Error in line {errorLine}. {errorTypes[0]} found, but ']' expected");
            }
        }
    }
}
