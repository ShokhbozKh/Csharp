using System;
using System.Collections.Generic;
using System.Drawing;

namespace Exercise_16
{

    internal class Person
    {
        public Person(string name, int yearOfBirth)
        {
            Name = name ?? throw new Exception("Name cannot be null");
            YearOfBirth = yearOfBirth;
            Car = null;
        }

        public Person(string name, int yearOfBirth, string carName, int red, int green, int blue) : this(name, yearOfBirth)
        {
            Car = new Car(carName, red, green, blue);
        }


        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public Car Car { get; set; }

        public static List<Car> FindAllCars(List<Person> list)
        {
            List<Car> carList = new List<Car>();

            foreach (Person person in list)
                if (person.Car is not null)
                    carList.Add(person.Car);

            return carList;
        }


        public override bool Equals(object obj)
        {
            Person personObj = obj as Person;
            if (personObj is not null && this.Name.Equals(personObj.Name) && this.YearOfBirth == personObj.YearOfBirth)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return this.YearOfBirth;
        }

        public override string ToString()
        {
            return Car is null ? $"Name: [{Name}], Year of Birth: [{YearOfBirth}]" : $"Name: [{Name}], Year of Birth: [{YearOfBirth}], Car: [{Car}]";
        }
    }

    internal class Car
    {
        public Car(string name, int red, int green, int blue)
        {
            Name = name;
            Color = Color.FromArgb(red, green, blue);
        }

        public string Name { get; set; }
        public Color Color { get; set; }

        public static List<Person> FindOwners(List<Person> list, string carName)
        {
            List<Person> owners = new List<Person>();

            foreach (Person person in list)
                if (person.Car is not null)
                    if(person.Car.Name.Equals(carName))
                        owners.Add(person);

            return owners;
        }

        public static Color FindColor(List<Person> list, String name, int year)
        {
            foreach (Person owner in list)
                if (owner.Equals(new Person(name, year)))
                    if (owner.Car is not null)
                        return owner.Car.Color;

            return Color.Empty;
        }

        public override string ToString()
        {
            return $"Brand: [{Name}], Color:[{Color}]";
        }
    }
}
