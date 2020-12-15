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


            #endregion
        }
    }
}
