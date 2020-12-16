﻿using Assignment_04.XOR;
using System;
using System.Linq;

namespace Assignment_04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Attributes
            Console.WriteLine("----- Attributes -----");

            Car car = new Car("WW 12F 2135", "Toyota", Category.Economy);
            Car.MAX_PRICE = 15;

            // Attribute price is derived from PROPERTY Price

            car.Price = 5;

            Console.WriteLine(car);

            #endregion

            #region Unique

            {
                Driver driver1 = new Driver("driver1", "password1", "license1");

                Console.WriteLine(driver1);

                Driver driver2 = null;

                try
                {
                    // Trying to make a new driver with already existing license
                    driver2 = new Driver("driver2", "password2", "license1");
                }
                catch (Exception)
                {
                }

                if (driver2 != null)
                {
                    Console.WriteLine(driver2);
                }
            }
            #endregion

            #region Subset
            Console.WriteLine();
            Console.WriteLine("----- Subset -----");
            Console.WriteLine();
            {
                // Driver works through Partners
                // Partner contains Drivers

                Driver driver3 = new Driver("driver3", "pass3", "lice3");
                Driver driver4 = new Driver("driver4", "pass4", "lice4");
                Driver driver5 = new Driver("driver5", "pass5", "lice5");

                Partner partner = new Partner(50, "Private Uber", 5);
                Partner partner2 = new Partner(40, "Uber Plus", 7.5);

                driver3.AddPartnerLink(partner);
                driver4.AddPartnerLink(partner);
                partner2.AddDriverLink(driver5);
                driver3.AddPartnerLink(partner2);

                // Trying to add existing partner
                driver4.AddPartnerLink(partner);

                // Trying to add existing driver
                partner.AddDriverLink(driver3);
            }

            #endregion

            #region Ordered
            Console.WriteLine();
            Console.WriteLine("----- Ordered -----");
            Console.WriteLine();
            {
                Client client = new Client("client1", "pass1");
                Client client1 = new Client("client2", "pass2");
                Client client2 = new Client("client3", "pass3");
                Client client3 = new Client("client4", "pass4");

                Request.MakeRequest(client, "Centrum", "Pole Mokotowski");
                Request.MakeRequest(client1, "Warszawa", "Gdansk");
                Request.MakeRequest(client2, "Centrum", "Biblioteka Narodowe");
                Request.MakeRequest(client3, "Plac konstytucji", "Mokotow");
                
                Driver driver = new Driver("driver1", RandomString(5), RandomString(5));
                Driver driver2 = new Driver("driver2", RandomString(5), RandomString(5));
                Driver driver3 = new Driver("driver3", RandomString(5), RandomString(5));
                Driver driver4 = new Driver("driver4", RandomString(5), RandomString(5));

                Request.ShowPendingRequests();

                driver.TakeRequest(1);
                driver2.TakeRequest(2);
                driver3.TakeRequest(3);
                driver4.TakeRequest(4);

                // Trying to take request which is already taken
                driver.TakeRequest(3);

                driver.ShowRides();
            }

            #endregion

            #region Bag

            // Client -> Ride <- Driver
            Console.WriteLine();
            Console.WriteLine("----- Bag ------");
            Console.WriteLine();

            {
                Client client = new Client("client1", RandomString(5));
                Driver driver = new Driver("driver1", RandomString(5), RandomString(5));

                Ride.AddRide(client, driver, "Centrum", "Kozykowa", 15, 5);

                client.ShowRides();
                driver.ShowRides();
            }

            #endregion

            #region XOR
            // Person 1 - * Picture * - 1 Museum
            Console.WriteLine();
            Console.WriteLine("----- XOR -----");
            Console.WriteLine();


            Person person = new Person("John", "Done", new DateTime());
            Museum museum = new Museum("Museum naradowe", "Iwicka 5", "National Museum", new DateTime());
            Picture picture = new Picture("Antony Robertson", "Random description", new DateTime())
            {
                PersonOwner = person
            };
            Console.WriteLine(picture.MuseumOwner);
            Console.WriteLine(picture.PersonOwner);

            picture.MuseumOwner = museum;
            Console.WriteLine(picture.MuseumOwner);
            Console.WriteLine(picture.PersonOwner);


            #endregion
        }

        static string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
