using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_15
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            try
            {
                MyHandler(1);
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region Task2
            List<MyException> exceptions = new List<MyException>();
            exceptions.Add(new MyException("First Exception"));
            exceptions.Add(new MyException("Second Exception"));
            exceptions.Add(new MyException("Third Exception"));

            foreach(MyException exception in exceptions)
                Console.WriteLine(exception.Message);
            #endregion

            #region Task3

            string text = "";

            try
            {   
                // Read from file
                text = File.ReadAllText(@"C:\Users\khido\OneDrive\Документы\GitHub\Csharp\Core\Exercise-15\Data\TextFile1.txt");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Could not find a file");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error has occured, please try again");
                Console.WriteLine($"Error message: {e.Message}");
            }

            #endregion

            #region Task4
            StringTokenizer st = new StringTokenizer(text, "");
            //If an empty delimiter is given, automatically uses " " (space).
            while (st.HasMoreTokens)
            {
                Console.WriteLine(st.NextToken());
            }
            string src2 = "Hello World!";
            st.NewSource(src2);
            while (st.HasMoreTokens)
            {
                Console.WriteLine(st.NextToken());
            }
            #endregion
        }

        public static void MyHandler(int number)
        {
            if (number == 1)
                throw new MyException("New Exception");
            else
                throw new FileNotFoundException("File was not found");
        }
    }
}
