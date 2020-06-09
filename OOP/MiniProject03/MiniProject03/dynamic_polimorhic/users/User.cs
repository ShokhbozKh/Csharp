using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
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

        /*
         * dynamic inheritance
         */
        private UserType _userType;

        private ICollection<AdvertisementType> _suitedAdvertisementTypes;

        public ICollection<AdvertisementType> SuitedAdvertisementTypes
        {
            get
            {
                if (_userType != UserType.BasicUser)
                {
                    return null;
                }

                return _suitedAdvertisementTypes.ToHashSet();
            }
            set
            {
                if (_userType != UserType.BasicUser)
                {
                    throw new Exception("The user is not a basic user");
                }

                _suitedAdvertisementTypes = value.ToList();
            }
        }

        private DateTime? _premiumEndDate;

        public DateTime? PremiumEndDate
        {
            get
            {
                if (_userType != UserType.PremiumUser)
                {
                    return null;
                }

                return _premiumEndDate;
            }
            set
            {
                if (_userType != UserType.PremiumUser)
                {
                    throw new Exception("The user is not a premium user");
                }

                _premiumEndDate = value;
            }
        }

        public User(string login, string password, DateTime? premiumEndDate,
            ICollection<AdvertisementType> suitedAdvertisementTypes, UserType userType)
        {
            Login = login;
            Password = password;
            UserId = new Guid();
            RegistrationDate = DateTime.Now;

            ListenEvents = new HashSet<ListenEvent>();
            Reviews = new HashSet<Review>();

            if (userType == UserType.BasicUser)
            {
                MakeBasic(suitedAdvertisementTypes);
            }
            else if (userType == UserType.PremiumUser)
            {
                MakePremium(premiumEndDate);
            }
        }

        #region previousTasks

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

        #endregion previuosTasks

        public void MakePremium(DateTime? premiumEndDate)
        {
            if (!premiumEndDate.HasValue)
            {
                throw new ArgumentNullException();
            }

            _userType = UserType.PremiumUser;
            _suitedAdvertisementTypes = null;
            _premiumEndDate = premiumEndDate;
        }

        public void MakeBasic()
        {
            MakeBasic(new HashSet<AdvertisementType>());
        }

        public void MakeBasic(ICollection<AdvertisementType> suitedAdvertisementTypes)
        {
            if (suitedAdvertisementTypes == null)
            {
                throw new ArgumentNullException();
            }

            _userType = UserType.BasicUser;
            _premiumEndDate = null;
            _suitedAdvertisementTypes = suitedAdvertisementTypes.ToHashSet();
        }

        public bool IsPremium() => _userType == UserType.PremiumUser;
        public bool IsBasic() => _userType == UserType.BasicUser;
    }
}