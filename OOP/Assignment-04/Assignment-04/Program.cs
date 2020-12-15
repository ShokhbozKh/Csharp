using System;
using System.Collections.Generic;

namespace Assignment_04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Attributes

            Car car = new Car("WW 12F 2135", "Toyota", Category.Economy);
            Car.MAX_PRICE = 15;

            // Attribute price is derived from PROPERTY Price

            car.Price = 5;

            Console.WriteLine(car);

            #endregion

            #region Unique

            Driver driver1 = new Driver("driver1", "password1", "license1");

            Console.WriteLine(driver1);

            Driver driver2 = null;

            try
            {
                // Trying to make a new driver with already existing license
                driver2 = new Driver("driver2", "password2", "license1");
            }
            catch(Exception)
            {
            }
            
            if(driver2 != null)
            {
                Console.WriteLine(driver2);
            }

            #endregion

            #region Subset

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

            #endregion
        }
    }
}
