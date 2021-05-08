using System;

namespace Assignment_03
{
    [Serializable]
    abstract class User : ObjectPlus
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region Constructors

        public User(string login, string password)
        {
            UserId = new Guid();
            Login = login;
            Password = password;
        }

        public User(string login, string password, string firstName, string lastName)
        {
            UserId = new Guid();
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion

        //public abstract void RequestRide();

        public override string ToString()
        {
            return $"Login: [{Login}], Password: [{Password}]";
        }
    }
}
