using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01
{
    [Serializable]
    class Review : ObjectPlus
    {
        public Ride Ride { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime ReviewDate { get; set; }

        public Review(Ride ride, string description, int rate, DateTime reviewDate)
        {
            Ride = ride;
            Description = description;
            Rate = rate;
            ReviewDate = reviewDate;

            AddReviewToDriver();
        }

        private void AddReviewToDriver()
        {
            Ride.Driver.AddReview(this);
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
