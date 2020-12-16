using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment_04
{
    [Serializable]
    class Client : User // Disjoint
    {
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

        private List<Ride> _rides = new List<Ride>();
        public List<Ride> Rides 
        {
            get => _rides;
            set => _rides = value ?? throw new NullReferenceException("Client cannot contain null rides!");
        }
        public DateTime RegistrationDate { get; set; }

        #region Constructors
        
        public Client(string login, string password) : base(login, password) 
        {
        }
        
        public Client(string login, string password, string firstName, string lastName) 
            : base(login, password, firstName, lastName) 
        {
        }

        #endregion

        public void AddRide(Ride ride)
        {
            if(_rides.Contains(ride))
            {
                Console.WriteLine("Client already has the given ride.");

                return;
            }

            Rides.Add(ride);
        }

        public void RemoveRide(Ride ride)
        {
            if (_rides.Contains(ride)) Rides.Remove(ride);
             
            Console.WriteLine("The client does not have the given ride.");
        }

        public void ShowRides()
        {
            if(_rides.Count > 0)
            {
                Console.WriteLine($"Rides for client: {this}");

                Console.WriteLine("-----");
                foreach (Ride ride in _rides)
                {
                    Console.WriteLine(ride);
                }
                Console.WriteLine("-----");

                return;
            }

            Console.WriteLine("The client does not have any ride yet!");
        }

        public static double GetAverageBall()
        {
            // Random avg ball for client between 1 and 5
            double avgBall = (double)new Random().NextDouble() * (5 - 1) + 1;

            // Change floating point precision to 2
            return Math.Round(avgBall, 2);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
