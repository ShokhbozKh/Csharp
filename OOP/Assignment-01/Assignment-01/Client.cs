using System;

namespace Assignment_01
{
    [Serializable]
    class Client : User
    {
        public DateTime RegistrationDate { get; set; }

        public Client(string login, string password) : base(login, password) { }
        public Client(string login, string password, 
            string firstName, string lastName) : base(login, password, firstName, lastName) { }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
