using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Assignment_02
{
    [Serializable]
    class Driver : User
    {
        #region Properties

        public DateTime LicenceValidationDate { get; set; }

        /*
         * Basic
         */
        private ICollection<Car> _cars = new List<Car>();
        private ICollection<Car> Cars
        {
            get => _cars.ToImmutableList();
            set => _cars = value ?? throw new NullReferenceException("Cars list cannot be null");
        }

        /*
         * With an attribute
         */
        private ICollection<Ride> _rides = new List<Ride>();
        public ICollection<Ride> Rides 
        {
            get => _rides;
            set => _rides = value ?? throw new NullReferenceException("Rides cannot be null!");
        }

        /*
         * Qualified
         */

        private readonly IDictionary<string, City> CitiesQualif = new Dictionary<string, City>();

        /*
         * Composition
         */
        private List<Review> _reviews = new List<Review>();
        public List<Review> Reviews
        {
            get => _reviews;
            set => _reviews = value;
        }

        #endregion

        #region Constructors
        public Driver(string login, string password) : base(login, password)
        {
        }
        public Driver(string login, string password,
            string firstName, string lastName) : base(login, password, firstName, lastName)
        {
        }

        #endregion

        #region Composition

        public void AddReview(Review review)
        {
            if (review != null && !_reviews.Contains(review))
            {
                _reviews.Add(review);
            }
        }

        public void RemoveReview(Review review)
        {
            if (_reviews.Contains(review))
                _reviews.Remove(review);
            else
                throw new Exception($"The driver does not contain review {review}");
        }

        #endregion

        #region With an attribute

        public void AddRide(Ride ride)
        {
            if (_rides.Contains(ride))
            {
                Console.WriteLine("The driver already has the given ride.");

                return;
            }

            _rides.Add(ride);
        }

        public void RemoveRide(Ride ride)
        {
            if (_rides.Contains(ride)) Rides.Remove(ride);

            Console.WriteLine("The driver does not have the given ride.");
        }

        #endregion

        #region Binary

        public void AddCar(Car car)
        {
            if (car == null || _cars.Contains(car)) return;

            _cars.Add(car);

            car.Driver = this;
        }

        public void RemoveCar(Car car)
        {
            if (car == null || !_cars.Contains(car)) return;

            _cars.Remove(car);
            car.Driver = null;
        }
        #endregion

        #region Class Method
        public static void ShowReviews(Driver driver)
        {
            if (driver._reviews.Count < 1)
            {
                Console.WriteLine($"Driver {driver.FirstName} does not have any reviews yet.");
                return;
            }

            foreach (Review review in driver._reviews)
            {
                Console.WriteLine(review.ToString());
            }
        }

        #endregion

        #region Qualified

        public void AddCityQualif(City city)
        {
            if (city == null) throw new ArgumentNullException("City qualifier cannot be null or empty");

            if (CitiesQualif.ContainsKey(city.CityName)) return;

            CitiesQualif.Add(city.CityName, city);
            city.AddDriver(this);
        }

        public void RemoveCityQualif(City city)
        {
            if (city == null) throw new ArgumentNullException("City qualifier cannot be null or empty");

            if (!CitiesQualif.ContainsKey(city.CityName)) return;

            CitiesQualif.Remove(city.CityName);
            city.RemoveDriver(this);
        }

        public void RemoveCityQualif(string cityName)
        {
            if (string.IsNullOrEmpty(cityName)) throw new ArgumentNullException("City qualifier cannot be null or empty");

            if (!CitiesQualif.ContainsKey(cityName)) return;

            City city = CitiesQualif[cityName];
            CitiesQualif.Remove(cityName);
            city.RemoveDriver(this);
        }

        public City FindQualif(string cityName)
        {
            if (string.IsNullOrEmpty(cityName)) throw new ArgumentNullException("City qualifier cannot be null or empty");

            if (!CitiesQualif.ContainsKey(cityName)) return null;

            return CitiesQualif[cityName];
        }

        #endregion

        #region Helper methods

        public void CheckIfExistsQualifArgs(object city)
        {
            if(city is City cityArg)
            {
                if (cityArg == null) throw new ArgumentNullException("City qualifier cannot be null or empty");

                if (!CitiesQualif.ContainsKey(cityArg.CityName)) throw new Exception($"The driver {this} does not contain city qualifier {cityArg.CityName}");
            }
            else if(city is String cityStringArg)
            {
                if (string.IsNullOrEmpty(cityStringArg)) throw new ArgumentNullException("City qualifier cannot be null or empty");

                if(!CitiesQualif.ContainsKey(cityStringArg)) throw new Exception($"The driver {this} does not contain city qualifier {cityStringArg}");
            }
        }

        public double GetAverageRate()
        {
            return _reviews.Average(s => s.Rate);
        }

        #endregion

        #region Object ovverridings
        
        public override string ToString()
        {
            return Login;
        }

        #endregion
    }
}
