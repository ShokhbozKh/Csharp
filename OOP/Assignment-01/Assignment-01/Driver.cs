using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Assignment_01
{
    [Serializable]
    class Driver : User
    {
        public Car Car { get; set; }
        public DateTime LicenceValidationDate { get; set; }

        /*
         * multi-value
         */
        private ICollection<Review> _reviews;
        public ICollection<Review> Reviews 
        { 
            get => _reviews.ToImmutableList();
            set => _reviews = value.ToList() ?? throw new ArgumentNullException("Reviews cannot contain null!"); 
        }

        public Driver(string login, string password) : base(login, password) 
        {
            _reviews = new List<Review>();
        }
        public Driver(string login, string password,
            string firstName, string lastName) : base(login, password, firstName, lastName) 
        {
            _reviews = new List<Review>();
        }

        public void AddReview(Review review)
        {
            if (review is null)
                throw new ArgumentNullException("Reviews cannot contain null!");

            _reviews.Add(review);
        }

        public void RemoveReview(Review review)
        {
            if (_reviews.Contains(review))
                _reviews.Remove(review);
            else
                throw new Exception("There is no such a review for given Driver!");
        }

        // Class Method
        public static void ShowReviews(Driver driver)
        {
            if(driver._reviews.Count < 1)
            {
                Console.WriteLine($"Driver {driver.FirstName} does not have any reviews yet.");
                return;
            }

            foreach(Review review in driver._reviews)
            {
                Console.WriteLine(review.ToString());
            }
        }

        public double GetAverageRate()
        {
            return _reviews.Average(s => s.Rate);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
