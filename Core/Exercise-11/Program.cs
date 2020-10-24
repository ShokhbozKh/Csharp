using System;
using System.IO;

namespace Exercise_11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Person
            Person john = new Person("John", "Done", 1920);
            Person robert = new Person("Robert", "Robertson", 1990);
            Person anna = new Person("Anna", "Whitacker", 1842);
            Person julia = new Person("Julia", "Robertson", 1993);
            Person james = new Person("James", "Bond", 1984);
            Person andrew = new Person("Andrew", "Anderson", 1923);
            Person lola = new Person("Lola", "Crew", 2002);
            Person joanna = new Person("Joanna", "Stamp", 1993);

            // GetOlder method test
            Console.WriteLine(Person.GetOlder(john, robert).ToString());

            // Show method test
            james.Show();

            // Get youngest female test
            // Should print Lola Crew
            // Print the result only if there is object returned from
            // GetYoungestFemale method is not null
            Console.WriteLine(Person.GetYoungestFemale(new Person[] { john, robert, anna, julia, james, andrew, lola, joanna })?.ToString()); 
            #endregion
        }
    }
}
