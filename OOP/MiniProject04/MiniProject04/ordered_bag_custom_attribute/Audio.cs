using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MiniProject04.ordered_bag_custom_attribute;

namespace MiniProject04
{
    public abstract class Audio
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();
        }

        /*
         * of attributes
         */
        private const int MaxDuration = 60 * 60 * 3;
        private int _duration;

        public int Duration
        {
            get => _duration;
            set
            {
                if (value <= 0 || value >= MaxDuration)
                {
                    throw new Exception("Audio cannot be shorter than 1 second or longer than 3 hours");
                }

                _duration = value;
            }
        }

        private User _owner;

        public User Owner
        {
            get => _owner;
            set => _owner = value ?? throw new ArgumentNullException();
        }

        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        /*
        * bag
        */
        private ICollection<ListenEvent> _listenEvents;

        public ICollection<ListenEvent> ListenEvents
        {
            get => _listenEvents.ToImmutableHashSet();
            set => _listenEvents = value ?? throw new ArgumentNullException();
        }


        public Audio(string name, int duration, User owner, DateTime releaseDate)
        {
            Name = name;
            Duration = duration;
            Owner = owner;
            ReleaseDate = releaseDate;

            ListenEvents = new HashSet<ListenEvent>();
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

        #region bag

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
    }
}