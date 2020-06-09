using System;
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

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            UserId = new Guid();
            RegistrationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Login: {Login} Password: {Password}";
        }
    }
}