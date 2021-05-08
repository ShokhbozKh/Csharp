using System;
using System.Collections.Generic;

namespace Assignment_02
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

        public void AddDriver(Driver driver)
        {
            if (driver == null) throw new ArgumentNullException("Driver cannot be null");

            if (drivers.Contains(driver)) return;

            drivers.Add(driver);
            driver.AddCityQualif(this);
        }

        public void RemoveDriver(Driver driver)
        {
            if (driver == null) throw new ArgumentNullException("Driver cannot be null");

            if (!drivers.Contains(driver)) return;

            drivers.Remove(driver);
            driver.RemoveCityQualif(this);
        }

        public override string ToString()
        {
            return $"City: [{CityName}], Province: [{Province}]";
        }
    }
}
