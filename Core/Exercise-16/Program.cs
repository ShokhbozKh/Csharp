using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_16
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            /* Task-01
            // Read from file
            TextReader txtFile = new StreamReader(@"Data\TextFile1.txt");
            string[] lines = txtFile.ReadToEnd().Split(
                            new[] { Environment.NewLine },
                            StringSplitOptions.None
                        );

            // Initialize parent stack
            ParentStack stack = new ParentStack();

            // To handle error message
            int errorPosition = -1;
            int errorLine = -1;

            // To check if there was an error during execution
            bool errorOccured = false;

            // Expected and actual results
            char expectedBracket = ' ';
            char foundBracket = ' ';

            // In case no error occured but there are brackets which are not closed
            string bracketsList = "";
            string errorText = "";

            foreach(string txt in lines)
                Console.WriteLine(txt);

            for(int i = 0; i < lines.OrderByDescending(s => s.Length).FirstOrDefault().Length; i++)
                Console.Write("-");

            Console.WriteLine();
            
            for(int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    // Check if element is type of openning bracket
                    // And push on to the stack
                    if (lines[i][j].Equals('('))
                        stack.Push(BracketType.LeftRound);
                    else if (lines[i][j].Equals('['))
                        stack.Push(BracketType.LeftSquare);
                    else if (lines[i][j].Equals('{'))
                        stack.Push(BracketType.LeftCurly);

                    // If stack is empty but the closing bracket is occured
                    // no data can be accessed from Pop method
                    else if (!stack.Empty())
                    {
                        // Check for closing type of brackets
                        // And pop from the stack
                        if (lines[i][j].Equals(')'))
                        {
                            BracketType poped = stack.Pop();

                            // If not expected bracket is popped
                            if ((char)poped != '(')
                            {
                                // Set error positions
                                errorLine = i + 1;
                                errorPosition = j + 1;

                                errorOccured = true;

                                // Set brackets details for error message
                                foundBracket = lines[i][j];
                                expectedBracket = GetExpectedValue(poped);

                                // Set error text
                                errorText = lines[i];

                                break;
                            }
                        }
                        else if (lines[i][j].Equals(']'))
                        {
                            BracketType poped = stack.Pop();

                            if ((char)poped != '[')
                            {
                                // Get error positions
                                errorLine = i + 1;
                                errorPosition = j + 1;

                                errorOccured = true;

                                // Set brackets details for error message
                                expectedBracket = GetExpectedValue(poped);
                                foundBracket = lines[i][j];
                                errorText = lines[i];

                                break;
                            }
                        }
                        else if (lines[i][j].Equals('}'))
                        {
                            BracketType poped = stack.Pop();

                            if ((char)poped != '{')
                            {
                                // Set error positions
                                errorLine = i + 1;
                                errorPosition = j + 1;

                                errorOccured = true;

                                // Set brackets details for error message
                                expectedBracket = GetExpectedValue(poped);
                                foundBracket = lines[i][j];

                                // Set error text
                                errorText = lines[i];

                                break;
                            }
                        }
                    }
                }
                
            }
            

            if (errorOccured)
            {
                Console.WriteLine(errorText);

                for (int i = 0; i < errorPosition; i++)
                {
                    Console.Write(" ");
                }

                Console.Write("^ \n");
                Console.WriteLine($"Error occured on line : {errorLine}, on position: {errorPosition}. '{foundBracket}' occured, but '{expectedBracket}' expected.");
            }
            else
            {
                if (stack.Empty())
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    while (!stack.Empty())
                    {
                        bracketsList += $"{(char)stack.Pop()} ";
                    }

                    Console.WriteLine("Not OK!");
                    Console.WriteLine($"List of unclosed brackets: {bracketsList}");
                }
            }

            */
            #endregion

            #region Task2
            /*
            TextReader txtFile = new StreamReader(@"Data\TextFile2.txt");
            string[] persons = txtFile.ReadToEnd().Split(
                            new[] { Environment.NewLine },
                            StringSplitOptions.None
                        );

            List<Person> owners = new List<Person>();

            foreach(string txt in persons)
            {
                string[] personDetails = txt.Split(" ");
                
                if(personDetails.Length > 2)
                {
                    Person person = new Person(personDetails[0], Convert.ToInt32(personDetails[1]), personDetails[2],
                        Convert.ToInt32(personDetails[3]), Convert.ToInt32(personDetails[4]), Convert.ToInt32(personDetails[5]));

                    owners.Add(person);
                }
                else
                {
                    Person person = new Person(personDetails[0], Convert.ToInt32(personDetails[1]));

                    owners.Add(person);
                }
            }

            

            List<Car> cars = Person.FindAllCars(owners);
            List<Person> owners1 = Car.FindOwners(owners, "Mercedes");
            Color JohnColor = Car.FindColor(owners, "John", 1980);
            Color AliceColor = Car.FindColor(owners, "Alice", 1993);
            Color MaryColor = Car.FindColor(owners, "Mary", 1997);

            // Owners
            Console.WriteLine("Owners:");
            foreach (Person person in owners)
                Console.WriteLine(person.ToString());
            Console.WriteLine("---------------");

            // Cars
            Console.WriteLine("Cars:");
            foreach(Car car in cars)
                Console.WriteLine(car.ToString());
            Console.WriteLine("---------------");

            // Owners of Mercedes
            Console.WriteLine("Owners of Mercedes:");
            foreach(Person person in owners1)
                Console.WriteLine(person.ToString());
            Console.WriteLine("---------------");

            // Colors
            Console.WriteLine($"Color of Alice's car: {AliceColor}");
            Console.WriteLine($"Color of John's car: {JohnColor}");
            Console.WriteLine($"Color of Mary's car: {MaryColor}");
            */
            #endregion

            #region Task3
            TextReader txtFile = new StreamReader(@"Data\TextFile3.txt");
            string[] txt = txtFile.ReadToEnd().Split(
                            new[] { Environment.NewLine },
                            StringSplitOptions.None
                        );
            Console.WriteLine("Purchases:");
            foreach(string purchase in txt)
                Console.WriteLine(purchase);
            Console.WriteLine("----------------");

            // Purchases
            Dictionary<string, List<Purchase>> purchases = new Dictionary<string, List<Purchase>>();


            foreach(string person in txt)
            {
                string[] personDetails = person.Split(" ");
                

                if (purchases.ContainsKey(personDetails[0]))
                {
                    purchases[personDetails[0]].Add(new Purchase(personDetails[1], Convert.ToDecimal(personDetails[2])));
                }
                else
                {
                    purchases.Add(personDetails[0], new List<Purchase>() 
                                                    {
                                                        new Purchase(personDetails[1], Convert.ToDecimal(personDetails[2]))
                                                    });
                }
            }

            foreach (KeyValuePair<string, List<Purchase>> purchase in purchases)
            {
                Console.Write($"{purchase.Key} ");
                Console.Write($"{purchases[purchase.Key].Count} ");
                Console.Write($"{purchases[purchase.Key].Select(s => s.Name).Distinct().Count()} ");
                Console.Write($"{purchases[purchase.Key].Sum(s => s.Price)} \n");
            }
            #endregion
        }

        static char GetExpectedValue(BracketType popedItem)
        {
            switch (popedItem)
            {
                case BracketType.LeftRound:
                    return (char)BracketType.RightRound;
                case BracketType.LeftSquare:
                    return (char)BracketType.RightSquare;
                case BracketType.LeftCurly:
                    return (char)BracketType.RightCurly;
                default:
                    return (char)BracketType.Default;
            }
        }
    }

}
