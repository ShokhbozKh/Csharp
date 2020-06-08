using static System.Console;

namespace Exercise_07
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(Norm("caravaggio"));
            WriteLine(Norm("VERMEER"));
            WriteLine(Init("johann sebastian bach"));
            WriteLine(Init("jorge LUIS BORGERS"));
            WriteLine(Init("WOLFGANG a. mozart"));
            WriteLine(tr("November 2016",
                "abcdefghijklmnopqrstuvwyz",
                "ABCDEFGHIJKLMNOPQRSTUVWYZ"));
            WriteLine(tr("abcXYZ", "aZcX", "||Cx"));
        }

        static string Norm(string name)
        {
            return name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1).ToLower();
        }

        static string Init(string name)
        {
            string[] fullName = name.Split(" ");
            string result = "";

            if(fullName.Length == 3)
            {
                result += fullName[0].Substring(0, 1).ToUpper() + ". ";
                result += fullName[1].Substring(0, 1).ToUpper() + ". ";
                result += fullName[2].Substring(0, 1).ToUpper() + fullName[2].Substring(1, fullName[2].Length - 1).ToLower();
            }

            return result;
        }

        static string tr(string s, string from, string to)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                int index = from.IndexOf(s[i]);

                if(index != -1)
                {
                    result += to[index];
                }else
                {
                    result += s[i];
                }
            }

            return result;
        }
    }
}
