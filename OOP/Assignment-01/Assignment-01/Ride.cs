using System;
using System.Collections.Generic;

namespace Assignment_01
{
    [Serializable]
    class Ride : ObjectPlus
    {
        public Guid IdRide { get; set; }
        public Client Client { get; set; }
        public Driver Driver { get; set; }
        public Address StartPoint { get; set; }
        public Address DestinationPoint { get; set; }
        public DateTime RideDate { get; set; }  // Complex attribute
        public string BonusType { get; set; }
        public static ICollection<string> BonusTypes = new List<string>();

        /*
         * optional attribute
         */
        public int? Bonus { get; set; }

        private static int _taxRate = 15;
        /*
         * class attribute
         */
        public static int Taxrate 
        {
            get => _taxRate;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Tax rate cannot be less than 0%");
                else if (value > 100)
                    throw new ArgumentException("Tax rate cannot be more than 100%");

                _taxRate = value;
            }
        }

        public decimal Price { get; set; }

        /*
         * derived attribute
         */        
        public decimal TotalPrice
        {
            get => Price - Taxrate;
        }        

        public Ride(Client client, Driver driver, string startPoint, string destinationPoint, DateTime rideDate, decimal totalPrice)
        {
            if (client is null)
                throw new Exception("Client data should be entered for the Ride information!");
            if (driver is null)
                throw new Exception("Driver data should be entered for the Ride information!");

            Client = client;
            Driver = driver;
            StartPoint = new Address(startPoint);
            DestinationPoint = new Address(destinationPoint);
            RideDate = rideDate;
            Price = totalPrice;
        }

        public Ride(Client client, Driver driver, string startPoint, string destinationPoint, DateTime rideDate, decimal totalPrice, int bonus)
        {
            Client = client;
            Driver = driver;
            StartPoint = new Address(startPoint);
            DestinationPoint = new Address(destinationPoint);
            RideDate = rideDate;
            Price = totalPrice;
            Bonus = bonus;
        }

        public void ShowExtent()
        {
            Console.WriteLine($"Extenet of the class: {nameof(Ride)}");
            int count = 0; // Counter for rides

            foreach(Ride ride in Extent[this.GetType()])
            {
                Console.WriteLine($"----- Ride: {++count} ------");
                Console.WriteLine(ride.ToString());
            }
        }

        public override string ToString()
        {
            return $"Client: [{Client}],\nDriver: [{Driver}],\nStart point: [{StartPoint}],\nDestination point:[{DestinationPoint}]," +
                $"\nRide date: [{RideDate}],\nTotal price: [{TotalPrice}]";
        }
    }
}
