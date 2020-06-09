using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace MiniProject01
{
    [Serializable]
    public class User : ObjectPlus
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        private ICollection<ListenEvent> _listenEvents;

        public ICollection<ListenEvent> ListenEvents
        {
            get => _listenEvents.ToImmutableHashSet();
            set => _listenEvents = value ?? throw new ArgumentNullException();
        }

        private ICollection<Review> _reviews;

        public ICollection<Review> Reviews
        {
            get => _reviews.ToImmutableHashSet();
            set => _reviews = value ?? throw new ArgumentNullException();
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            UserId = new Guid();
            RegistrationDate = DateTime.Now;
            
            ListenEvents = new HashSet<ListenEvent>();
            Reviews = new HashSet<Review>();
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

        public override string ToString()
        {
            return $"{{Login: \"{Login}\" Name: \"{Name}\"}}";
        }
    }
}