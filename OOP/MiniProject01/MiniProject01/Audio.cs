using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MiniProject01
{
    [Serializable]
    public abstract class Audio : ObjectPlus
    {
        /*
         * class attribute
         */
        public static int MaxDuration { get; set; } = 60 * 60 * 3;

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();
        }

        public int Duration { get; set; }

        private User _owner;

        public User Owner
        {
            get => _owner;
            set => _owner = value ?? throw new ArgumentNullException();
        }

        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public long ListenCount { get; set; }

        /*
         * multi-value
         */
        private ICollection<Review> _reviews;
        public ICollection<Review> Reviews
        {
            get => _reviews.ToImmutableList();
            set => _reviews = value.ToList() ?? throw new ArgumentNullException();
        }

        public double Rating => Reviews.Average(r => r.Rate);


        protected Audio(string name, int duration, User owner, DateTime releaseDate)
        {
            Reviews = new List<Review>();
            Name = name;
            if (duration > MaxDuration)
            {
                throw new Exception("duration must be lower than 3 hrs");
            }

            Duration = duration;
            Owner = owner;
            ListenCount = 0;
            ReleaseDate = releaseDate;
        }

        public virtual void Play()
        {
            ListenCount++;
            Console.WriteLine($"Audio {Name} stared playing");
        }

        public int PlayingAt()
        {
            return 0;
        }

        public virtual void Stop()
        {
            Console.WriteLine($"Audio {Name} stopped playing");
        }

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public void RemoveReview(Review review)
        {
            _reviews.Remove(review);
        }

        public static ICollection<Audio> GetMostListenedAudios(Type type, int topCount)
        {
            return Extent[type]
                .Select(a => (Audio) a)
                .OrderByDescending(a => a.ListenCount)
                .Take(topCount)
                .ToList();
        }

    }
}