using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MiniProject01
{
    [Serializable]
    public abstract class Audio : ObjectPlus, IDisposable
    {
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

        /*
         * qualified
         */
        private IDictionary<int, AudioText> _text;

        public IDictionary<int, AudioText> Text
        {
            get => _text.ToImmutableDictionary();
            set => _text = value ?? throw new ArgumentNullException();
        }

        /*
         * attribute
         */
        private ICollection<ListenEvent> _listenEvents;

        public ICollection<ListenEvent> ListenEvents
        {
            get => _listenEvents.ToImmutableHashSet();
            set => _listenEvents = value ?? throw new ArgumentNullException();
        }

        /*
         * composition
         */
        private ICollection<Review> _reviews;

        public ICollection<Review> Reviews
        {
            get => _reviews.ToImmutableList();
            set => _reviews = value ?? throw new ArgumentNullException();
        }

        private static ICollection<Review> _allReviews = new HashSet<Review>();

        public static ICollection<Review> AllReviews
        {
            get => _allReviews.ToImmutableHashSet();
            set => _allReviews = value ?? throw new ArgumentNullException();
        }

        public double Rating => Reviews.Average(r => r.Rate);

        protected Audio(string name, int duration, User owner, DateTime releaseDate)
        {
            Name = name;
            if (duration > MaxDuration)
            {
                throw new Exception("duration must be lower than 3 hrs");
            }

            Duration = duration;
            Owner = owner;
            ReleaseDate = releaseDate;

            ListenEvents = new HashSet<ListenEvent>();
            Text = new Dictionary<int, AudioText>();
            Reviews = new HashSet<Review>();
        }

        public virtual void Play(User user)
        {
            ListenEvent.AddListenEvent(user, this);
            Console.WriteLine($"Audio {Name} stared playing");
        }

        public int PlayingAt()
        {
            return 0;
        }

        public virtual void Stop(User user)
        {
            Console.WriteLine($"Audio {Name} stopped playing");
        }

        public static ICollection<Audio> GetMostListenedAudios(Type type, int topCount)
        {
            return Extent[type]
                .Select(a => (Audio) a)
                .OrderByDescending(a => a._listenEvents.Count)
                .Take(topCount)
                .ToList();
        }

        #region attribute

        public void AddListenEvent(ListenEvent listenEvent)
        {
            if (listenEvent == null || _listenEvents.Contains(listenEvent))
            {
                return;
            }

            _listenEvents.Add(listenEvent);
        }

        public void RemoveListenEvent(ListenEvent listenEvent)
        {
            if (listenEvent == null || !_listenEvents.Contains(listenEvent))
            {
                return;
            }

            _listenEvents.Remove(listenEvent);
        }

        #endregion

        #region qualified

        public void AddText(AudioText text)
        {
            if (text == null || _text.ContainsKey(text.Second) || text.Second > Duration)
            {
                return;
            }

            _text.Add(text.Second, text);
            text.Audio = this;
        }

        public void RemoveText(AudioText text)
        {
            if (text == null || !_text.ContainsKey(text.Second))
            {
                return;
            }

            _text.Remove(text.Second);
            text.Audio = null;
        }

        public AudioText GetTextAtSecond(int second)
        {
            return !_text.ContainsKey(second) ? null : _text[second];
        }

        #endregion

        #region composition

        public void AddReview(Review review)
        {
            if (review == null || _reviews.Contains(review) || _allReviews.Contains(review))
            {
                return;
            }

            _reviews.Add(review);
            _allReviews.Add(review);
        }

        public void RemoveReview(Review review)
        {
            if (review == null)
            {
                return;
            }

            _reviews.Remove(review);
            _allReviews.Remove(review);
        }

        #endregion

        public void Dispose()
        {
            foreach (var review in _reviews)
            {
                _allReviews.Remove(review);
            }
        }
    }
}