using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_11
{
    class Person
    {
        string Name { get; set; }
        string LastName { get; set; }
        int YearOfBirth { get; set; }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            YearOfBirth = 1990;
        }

        public Person(string name, string lastName, int yearOfBirth)
        {
            Name = name;
            LastName = LastName;
            YearOfBirth = yearOfBirth;
        }

        public string GetName() => $"{Name} {LastName}";

        public int GetBirthYear() => YearOfBirth;

        public bool IsFemale() => Name.EndsWith("a");

        // Get older person by comparing year of birth
        public static Person GetOlder(Person objX, Person objY)
        {
            return objX.YearOfBirth > objY.YearOfBirth ? objY : objX;
        }

        // Get youngest female from person array
        public static Person GetYoungestFemale(Person[] people)
        {
            // Set initial person object
            Person youngest;

            // Because of number of women in the array is unkown
            // length of array will be equal to the length of people array
            Person[] women = new Person[people.Length];
            int arrCounter = 0;

            // Get all women from the person array
            for (int i = 0; i < people.Length; i++)
                if (people[i].IsFemale())
                    women[arrCounter++] = people[i];

            // Set the initial youngest woman to the first
            // person in the array
            youngest = women[0];

            // Check if there are younger women than the initial object
            for (int i = 1; i < women.Length; i++)
                if(women[i] is not null)
                    if (youngest.YearOfBirth < women[i].YearOfBirth)
                        youngest = women[i];

            return youngest;
        }

        // Show detials of the person
        public void Show()
        {
            Console.WriteLine($"Person: [{Name}] [{LastName}] [{YearOfBirth}]");
        }

        public override string ToString()
        {
            return $"Person: [{Name}] [{LastName}] [{YearOfBirth}]";
        }
    }
}
