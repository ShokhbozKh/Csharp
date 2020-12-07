using System;

namespace Assignment_04
{
    [Serializable]
    class Review : ObjectPlus
    {
        public Guid IdReview { get; set; }
        public Ride Ride { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime ReviewDate { get; set; }

        public Review(Ride ride, string description, int rate, DateTime reviewDate)
        {
            IdReview = new Guid();
            Ride = ride;
            Description = description;
            Rate = rate;
            ReviewDate = reviewDate;

            AddReviewToDriver();
        }

        #region Composition

        public static Review AddReview(Ride ride, string description, int rate)
        {
            if(string.IsNullOrEmpty(description) || ride == null)
            {
                Console.WriteLine("Please, enter correct details of the review.");

                return null;
            }

            var newReview = new Review(ride, description, rate, DateTime.Now);
            ride.Driver.AddReview(newReview);
            return newReview;
        }

        #endregion

        // Ensure biderection of the association
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
