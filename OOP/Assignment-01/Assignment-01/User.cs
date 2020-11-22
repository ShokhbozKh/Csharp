using System;

namespace Assignment_01
{
    [Serializable]
    class User : ObjectPlus
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

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

        public override string ToString()
        {
            return $"Login: {Login}, Password: {Password}";
        }
    }
}
