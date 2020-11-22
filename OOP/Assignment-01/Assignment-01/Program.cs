using System;

namespace Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Objects instantiating
             */

            // Clients
            Client client1 = new Client("client1", "password1");
            Client client2 = new Client("client2", "password2", "John", "Done");

            // Drivers
            Driver driver1 = new Driver("Driver1", "password1");
            Driver driver2 = new Driver("Driver2", "password2");

            // Cars
            Car car1 = new Car("AA 212 24", "Szkoda fabia", Category.Economy);
            Car car2 = new Car("BA 777", "Mercedez Benz", Category.Bussiness);

            // Rides

            /*
             * Class attribute
             */
            Ride.Taxrate = 15;

            Ride ride1 = new Ride(client1, driver1, "Centrum", "Stadion Narodowe", DateTime.Now, 20);

            /*
             * Constructor overloading
             */
            Ride ride2 = new Ride(client1, driver2, "Rondo ONZ", "Warszawa Centralna", DateTime.Now.AddDays(1), 30);

            Ride ride4 = new Ride(client2, driver2, "Ursynow", "Mokotow", DateTime.Now, 15);
            /*
             * Optional attribute -> bonus rate
             */
            Ride ride3 = new Ride(client2, driver1, "Pole Mokotowskie", "Kozykowa", DateTime.Now, 15, 10);

            /*
             * Derived attribute -> total price + tax rate - bonus rate(optional)
             */
            Console.WriteLine($"Pice for the ride: {ride3.TotalPrice}");

            // Reviews

            /*
             * multi value Driver -> * reviews
             */
            Review review1 = new Review(ride1, "Very well", 5, DateTime.Now);   // Complex attributes
            Review review2 = new Review(ride2, "Very bad!!!", 0, DateTime.Now);
            Review review3 = new Review(ride3, "So so", 2, DateTime.Now);
            Review review4 = new Review(ride4, "Nice", 4, DateTime.Now);

            /*
             * Class method
             */
            Driver.ShowReviews(driver2);

            /*
             * Extent
             */
            ride1.ShowExtent();

            var fileName = "TextFile.txt";
            ObjectPlus.SerializeToFile(fileName);
            ObjectPlus.DeserializeFromFile(fileName);
        }
    }
}
