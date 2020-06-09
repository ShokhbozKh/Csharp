using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace MiniProject04.ordered_bag_custom_attribute
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        /*
         * custom
         */
        private string _email;

        public string Email
        {
            get => _email;
            set
            {
                if (!Regex.IsMatch(value, EmailRegex))
                {
                    throw new Exception("Invalid email");
                }

                _email = value;
            }
        }

        private const string EmailRegex =
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        private ICollection<ListenEvent> _listenEvents;

        public ICollection<ListenEvent> ListenEvents
        {
            get => _listenEvents.ToImmutableHashSet();
            set => _listenEvents = value ?? throw new ArgumentNullException();
        }

        public User(string login, string password, string email, DateTime? premiumEndDate)
        {
            Login = login;
            Password = password;
            Email = email;
            UserId = new Guid();
            RegistrationDate = DateTime.Now;

            ListenEvents = new HashSet<ListenEvent>();
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