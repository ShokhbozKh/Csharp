using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void RemoveReviews(int rate)
        {
            List<ObjectPlus> result = Extent[typeof(Review)].ToList();

            int g = 0;

            foreach (var r in result)
            {
                var review = r as Review;
                if(review.Rate < rate)
                {
                    result.Remove(r);
                }
            }

            int s = 0;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
