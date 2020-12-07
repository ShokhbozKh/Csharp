using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_04
{
    class City
    {
        public string CityName { get; set; }
        public string Province { get; set; }

        private readonly ICollection<Driver> drivers;

        public City(string cityName, string province)
        {
            CityName = cityName;
            Province = province;
            drivers = new List<Driver>();
        }

        #region Qualified

        public void AddDriver(Driver driver)
        {
            if (drivers.Contains(driver))
            {
                Console.WriteLine("The driver already belongs to this city");

                return;
            }

            drivers.Add(driver);
        }

        public void ShowDrivers()
        {
            Console.Write($"Drivers belonging to the {CityName}: ");

            foreach(Driver driver in drivers)
                Console.Write($"{driver} ");
        }

        #endregion

        public override string ToString()
        {
            return $"City: [{CityName}], Province: [{Province}]";
        }
    }
}
