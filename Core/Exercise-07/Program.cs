using System;
using System.Linq;

namespace Exercise_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Norm("caravaggio"));
            Console.WriteLine(Norm("VERMEER"));
            Console.WriteLine(Init("johann sebastian bach"));
            Console.WriteLine(Init("i. babeL"));
            Console.WriteLine(Init("jorge LUIS BORGES"));
            Console.WriteLine(Init("WOLFGANG a.mozart"));
            Console.WriteLine(Tr("November 2016",
                                "abcdefghijklmnopqrstuvwyz",
                                "ABCDEFGHIJKLMNOPQRSTUVWYZ"));
            Console.WriteLine(Tr("abcXYZ", "aZcX", "||Cx"));
        }

        static string Norm(string name)
        {
            return String.Concat(name.Substring(0, 1).ToUpper(), name.Substring(1).ToLower());
        }

        static string Init(string name)
        {
            string result = "";

            string[] nameArr = name.Split(" ");

            for(int i = 0; i < nameArr.Length; i++)
            {
                if (i == nameArr.Length - 1)
                    result += nameArr[i];
                else
                    result += nameArr[i].Substring(0, 1).ToUpper() + ". ";
            }

            return result;
        }

        static string Tr(string s, string from, string to)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if (from.Contains(s[i]))
                    s = s.Replace(s[i], to.ElementAt(from.IndexOf(s[i])));
            }
            
            return s;
        }
    }
}
