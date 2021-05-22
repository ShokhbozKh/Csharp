using Assignment_03.Dynamic;
using System;
using System.Collections.Generic;

namespace Assignment_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Objects Instantiating

            Client client1 = new Client("client_login1", "password1", "John", "Done");
            Client client2 = new Client("client_login2", "password2", "Robert", "Robertson");

            List<Client> clients = new List<Client>
            {
                client1,
                client2
            };

            CustomerSupport customerSupport1 = new CustomerSupport("cs1", "password1", 1750.50m);
            CustomerSupport customerSupport2 = new CustomerSupport("cs2", "password2", 1850.50m);

            customerSupport1.WorkHours = 40;
            customerSupport2.WorkHours = 38;

            List<CustomerSupport> customerSupports = new List<CustomerSupport>
            {
                customerSupport1,
                customerSupport2
            };

            Driver driver1 = new Driver("d1", "password1", "Anderson", "Silva");
            Driver driver2 = new Driver("d2", "password2", "Steve", "Spligberg");

            List<Driver> drivers = new List<Driver>
            {
                driver1,
                driver2
            };

            Car car1 = new Car("c13212", "ferarri", Category.Bussiness);
            Car car2 = new Car("c13432", "BMW", Category.Economy);

            List<Car> cars = new List<Car>
            {
                car1,
                car2
            };

            driver1.AddCar(car1);
            driver2.AddCar(car2);

            List<string> streets = new List<string>
            {
                "Centrum", "Stadion Narodowe", "Rondo ONZ", "Warszawa Centralna",
                "Ursynow", "Mokotow", "Pole Mokotowskie", "Kozykowa", "Biblioteka Narodowe"
            };


            // Generate rides
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

            #region Abstract Polymorphic method call

            /*
             * Abstract User class
             */

            Console.WriteLine();
            Console.WriteLine("------- Abstract -----------");
            Console.WriteLine();

            Employee employee = driver1;

            Console.WriteLine($"Income of driver {employee} is: {employee.GetIncome()}");

            employee = customerSupport1;

            Console.WriteLine($"Income of customer support {employee.Login} is: {employee.GetIncome()}");

            #endregion

            #region Overlapping

            /*
             * Flattening the hierarchy
             */

            Console.WriteLine();
            Console.WriteLine("------- Overlapping ----------");
            Console.WriteLine();

            Partner partner = new Partner(50, "Driving partner uber sp.zoo", 5);
            partner.AddPartnerType(PartnerType.AgencyPartner);
            partner.AddPartnerType(PartnerType.IndividualPartner);
            partner.AddPartnerType(PartnerType.PrivatePartner);

            partner.ShowTypes();

            // Generating error by adding existing type to the partner
            partner.AddPartnerType(PartnerType.PrivatePartner);

            partner.RemovePartnerType(PartnerType.AgencyPartner);
            // Generating error by removing non-belonging type to the partner
            partner.RemovePartnerType(PartnerType.AgencyPartner);

            #endregion

            #region Multi inheritance

            Console.WriteLine();
            Console.WriteLine("------- Multi inheritance ----------");
            Console.WriteLine();

            #endregion

            #region Multi aspect

            Employee csEmp = customerSupport1;
            Employee driverEmp = driver1;

            WorkMode.AssignWorkMode(csEmp, new PartTime());
            WorkMode.AssignWorkMode(driverEmp, new FullTime());

            #endregion

            #region Dynamic

            Console.WriteLine();
            Console.WriteLine("--------- Dynamic inheritance -------- ");
            Console.WriteLine();

            Company limitedCompany = new Company("Boring LTD", 1500000);
            Limited.EstablishLimitedCompany(limitedCompany, 150, 20000);

            Console.WriteLine("Limited company details: ", limitedCompany);
            Console.WriteLine("--- Transform to registered");
            Console.WriteLine();

            limitedCompany.TransformToRegistered("Education");
            Console.WriteLine(limitedCompany);
            #endregion
        }
    }
}
