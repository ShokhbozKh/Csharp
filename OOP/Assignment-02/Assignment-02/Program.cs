using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generating Clients instances
            Client client1 = new Client("client1", "password1");
            Client client2 = new Client("client2", "password2", "John", "Done");
            Client client3 = new Client("client3", "password3", "Andrew", "Johnson");
            Client client4 = new Client("client3", "password3", "James", "Bond");

            List<Client> clients = new List<Client>
            {
                client1,
                client2,
                client3,
                client4
            };

            // Generating Drivers instances
            Driver driver1 = new Driver("Driver1", "password1");
            Driver driver2 = new Driver("Driver2", "password2");
            Driver driver3 = new Driver("Driver3", "password3", "Matt", "Anderson");
            Driver driver4 = new Driver("Driver4", "password4", "Jim", "Gray");

            List<Driver> drivers = new List<Driver>
            {
                driver1,
                driver2,
                driver3,
                driver4
            };

            // Generating Cars instances
            Car car1 = new Car("AA 212 24", "Szkoda fabia", Category.Economy);
            Car car2 = new Car("BA 777", "Mercedez Benz", Category.Bussiness);
            Car car3 = new Car("AA 212 24", "Bently", Category.Lux);
            Car car4 = new Car("WW 123 421", "Porche", Category.Bussiness);

            List<Car> cars = new List<Car>
            {
                car1,
                car2,
                car3,
                car4
            };

            // Basic association -> Driver 1 - * Cars

            Console.WriteLine("---- Basic assocation ---- ");

            for (int i = 0; i < cars.Count; i++)
            {
                if (i % 2 == 0)
                    cars[i].Driver = driver1;
                else
                    cars[i].Driver = driver2;
            }

            Console.WriteLine("Cars before reassigning:");
            cars.ForEach(Console.WriteLine);

            // Basic association - reassigning cars to another drivers
            for (int i = 0; i < cars.Count; i++)
            {
                if (i % 2 == 0)
                    cars[i].Driver = driver2;
                else
                    cars[i].Driver = driver1;
            }

            Console.WriteLine("Cars after reassigning:");
            cars.ForEach(Console.WriteLine);
            Console.WriteLine();

            /*
             * With an attribute association
             */
            Console.WriteLine("---- With an attribute -----");
            List<string> streets = new List<string>
            {
                "Centrum", "Stadion Narodowe", "Rondo ONZ", "Warszawa Centralna",
                "Ursynow", "Mokotow", "Pole Mokotowskie", "Kozykowa", "Biblioteka Narodowe"
            };

            List<Ride> rides = new List<Ride>();

            foreach (Client client in clients)
            {
                for (int i = 0; i < 5; i++)
                {
                    foreach (Driver driver in drivers)
                    {
                        rides.Add(Ride.AddRide(client, driver,
                            streets[new Random().Next(8)], streets[new Random().Next(8)],
                            new Random().Next(50)));
                    }
                }
            }

            Console.WriteLine($"Average number of clients rides: {clients.Average(s => s.Rides.Count())}");
            Console.WriteLine($"Average number of drivers rides: {drivers.Average(s => s.Rides.Count())}");
            Console.WriteLine();

            /*
             * Qualified
             */

            Console.WriteLine("---- Qualified ----");

            List<City> cityList = new List<City>
            {
                new City("Warsaw", "Mazowian"),
                new City("Nowy Dwor Mazowiecki", "Mazowian"),
                new City("Lodz", "Lodz Province"),
                new City("Krakow", "Krakow Province")
            };

            foreach (Driver driver in drivers)
                driver.AddCityQualif(cityList[new Random().Next(4)]);

            Console.WriteLine(drivers[0].FindCityQualif("Warsaw"));
            Console.WriteLine(drivers[1].CitiesQualif.Count);
            Console.WriteLine();

            /*
             * Composition
             */

            Console.WriteLine("---- Composition ---- ");
            List<string> reviewsDescr = new List<string>
            {
                "I forgot my phone in the car", "Driver was slow",
                "I waited my car for 30 minutes", "Driver charged me more than it was shown by app",
                "Awesome ride", "Cool", "Nice", "Driver was very nice"
            };

            for (int i = 0; i < rides.Count; i++)
            {
                Review.AddReview(rides[i], reviewsDescr[new Random().Next(8)], new Random().Next(6));
            }

            Console.WriteLine($"{drivers[2]} has an average rate in {drivers[2].Reviews.Count} rides: {drivers[2].GetAverageRate()}");
        }
    }
}
