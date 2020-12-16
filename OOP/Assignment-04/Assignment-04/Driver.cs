using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Assignment_04
{
    [Serializable]
    class Driver : Employee
    {
        private static Dictionary<string, Driver> DRIVER_LICENSES { get; set; }
        public DateTime LicenseValidationDate { get; set; }

        private ICollection<Car> _cars = new List<Car>();
        private ICollection<Car> Cars
        {
            get => _cars.ToImmutableList();
            set => _cars = value ?? throw new NullReferenceException("Cars list cannot be null");
        }
        private ICollection<Ride> _rides = new List<Ride>();
        public ICollection<Ride> Rides
        {
            get => _rides;
            set => _rides = value ?? throw new NullReferenceException("Rides cannot be null!");
        }

        private readonly ICollection<Partner> _partners = new List<Partner>();
        public ICollection<Partner> Partners;

        private List<Review> _reviews = new List<Review>();
        public List<Review> Reviews
        {
            get => _reviews;
            set => _reviews = value;
        }

        #region Constructors
        static Driver()
        {
            DRIVER_LICENSES = new Dictionary<string, Driver>();
        }

        public Driver(string login, string password, string license) : base(login, password, Position.Driver)
        {
            if(DRIVER_LICENSES.ContainsKey(license))
            {
                throw new Exception("The given license already exists! The Driver cannot be added.");                
            }

            DRIVER_LICENSES.Add(license, this);
        }

        public Driver(string login, string password,
            string firstName, string lastName) : base(login, password, firstName, lastName, Position.Driver)
        {
        }

        #endregion

        public void AddReview(Review review)
        {
            if (review is null || _reviews.Contains(review))
                return;

            _reviews.Add(review);
            
        }

        public void RemoveReview(Review review)
        {
            if (_reviews.Contains(review))
                _reviews.Remove(review);
            else
                Console.WriteLine($"The driver ${ToString()} does not contain review with id: {review.IdReview}");
        }

        public void AddRide(Ride ride)
        {
            var r = _rides.Any(s => s.IdRide == ride.IdRide);
            if (_rides.Any(s => s.IdRide == ride.IdRide))
            {
                Console.WriteLine("The driver already has the given ride.");

                return;
            }

            _rides.Add(ride);
        }

        public void RemoveRide(Ride ride)
        {
            if (_rides.Any(s => s.IdRide == ride.IdRide))
            {
                Rides.Remove(ride);

                return;
            }

            Console.WriteLine("The driver does not have the given ride.");
        }

        public void ShowRides()
        {
            if (_rides.Any())
            {
                Console.WriteLine($"Rides for driver: {this}");

                Console.WriteLine("-----");

                foreach(Ride ride in _rides)
                    Console.WriteLine(ride);

                Console.WriteLine("-----");

                return;
            }

            Console.WriteLine("The driver does not have any rides yet!");
        }

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

        public double GetAverageRate()
        {
            return _reviews.Average(s => s.Rate);
        }

        public void ShowCars()
        {
            if (Cars.Count > 0)
            {
                Console.WriteLine($"{Login} Cars:");

                foreach (Car car in Cars) Console.WriteLine(car.ToString());
            }
        }

        public void AddPartnerLink(Partner partner)
        {
            if(partner is null)
            {
                Console.WriteLine("Partner cannot be null!");

                return;
            }

            if (_partners.Any(s => s.IdPartner == partner.IdPartner))
            {
                Console.WriteLine($"The driver already contains {partner.PartnerName} partner");
            }

            _partners.Add(partner);
            partner.AddDriverLink(this);
        }

        public void RemovePartnerLink(Partner partner)
        {
            if(partner is null)
            {
                Console.WriteLine("Partner cannot be null!");

                return;
            }

            if(_partners.Any(s => s.IdPartner == partner.IdPartner))
            {
                Console.WriteLine($"The driver does not cooperate with {partner.PartnerName}");

                return;
            }

            _partners.Remove(partner);
            partner.RemoveDriverLink(this);
        }

        public void TakeRequest(int requestIndex)
        {
            Request.AcceptRequest(this, requestIndex);
        }

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

        public static void ShowRequests()
        {
            Request.ShowPendingRequests();
        }

        #endregion

        internal override decimal GetIncome()
        {
            decimal totalSum = 0;

            foreach(Ride ride in _rides)
            {
                totalSum += ride.TotalPrice;
            }

            totalSum -= ((totalSum * TaxRate) / 100);

            return totalSum;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
