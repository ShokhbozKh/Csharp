using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Objects Instantiating

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

            // Assigning cars to drivers
            for (int i = 0; i < cars.Count; i++)
            {
                if (i % 2 == 0)
                    cars[i].Driver = driver1;
                else
                    cars[i].Driver = driver2;
            }

            // Generating Customer support employee
            CustomerSupport customerSupport1 = new CustomerSupport("Support1", "password1", 4500);
            CustomerSupport customerSupport2 = new CustomerSupport("Support2", "password1", 5000);

            // Generating Rides
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
            #endregion

            #region Disjoint

            /*
             * Client -> User <- Employee
             */


            #endregion

            #region Abstract

            /*
             * Abstract User class
             */

            #endregion

            #region Polymorphic method call

            // Set tax rate for employees
            Employee.TaxRate = 30;

            Employee user1 = driver1;
            Employee user2 = customerSupport1;

            Console.WriteLine($"Income method result for driver: {user1.GetIncome()}");
            Console.WriteLine($"Income method result for customer support: {user2.GetIncome()}");

            #endregion

        }
    }
}
