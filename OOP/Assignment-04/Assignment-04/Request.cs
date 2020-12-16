using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_04
{
    class Request
    {
        public Guid IdRequest { get; set; }

        private Client Client { get; set; }

        private bool requestAccepted;

        private string StartPoint { get; set; }
        private string DestinationPoint { get; set; }
        private static decimal Price
        {
            get => (decimal)new Random().Next(50);
        }
        private static int Bonus 
        {
            get => (int)new Random().Next(10);
        }
        private static decimal TotalPrice
        {
            get => Price - ((Bonus * Price) / 100); // Substract percent of bonus from price
        }

        private static readonly List<Request> _pendingRequests = new List<Request>();

        // We don't need object of this class but at the same time we don't need
        // it to be abtract nor static
        private Request(Client client, string startPoint, string destinationPoint)
        {
            IdRequest = Guid.NewGuid();
            StartPoint = startPoint;
            DestinationPoint = destinationPoint;
            Client = client;
        }

        public static void MakeRequest(Client client, string startPoint, string destinationPoint)
        {
            if(string.IsNullOrWhiteSpace(startPoint) || string.IsNullOrWhiteSpace(destinationPoint))
            {
                Console.WriteLine("Please, enter a valid coordinates!");

                return;
            }

            if(client is null)
            {
                Console.WriteLine("Client cannot be null!");

                return;
            }

            _pendingRequests.Add(new Request(client, startPoint, destinationPoint));
        }

        public static void ShowPendingRequests()
        {
            int counter = 0; // to count position of request for driver's to accept it by index
            
            if(_pendingRequests.Count <= 0)
            {
                Console.WriteLine("There are no pending requests now.");

                return;
            }

            Console.WriteLine("Pending requests:");
            foreach(Request request in _pendingRequests)
            {
                Console.WriteLine($"Request number: {++counter} - {request}");
            }
        }

        public static void AcceptRequest(Driver driver, int requestNumber)
        {
            if(driver is null)
            {
                Console.WriteLine("Driver cannot be null!");
                
                return;
            }

            string message = string.Empty;
            
            try
            {
                for(int i = 0; i < _pendingRequests.Count; i++)
                {
                    if(i == requestNumber)
                    {
                        var request = _pendingRequests[i];

                        if(request.requestAccepted)
                        {
                            Console.WriteLine("This request already has been accepted!");
                        }

                        Ride.AddRide(request.Client, driver, request.StartPoint, request.DestinationPoint, TotalPrice, Bonus);

                        // remove the accepted request
                        request.requestAccepted = true;

                        message = "The request accepted succesfully!";
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
                message = "Incorrect request was selected, please try again!";
            }
            catch(ArgumentException)
            {
                message = "Sorry, there was a problem with accepting the request. Please, try later.";
            }
            catch(Exception)
            {
                message = "Something went wrong... Please, try later.";
            }
            finally
            {
                if(string.IsNullOrEmpty(message))
                    Console.WriteLine("Something went wrong... Please, try later.");
                else
                    Console.WriteLine(message);
            }
        }

        public override string ToString()
        {
            return $"Start point: [{StartPoint}] - Destination point: [{DestinationPoint}] - Total price: [{TotalPrice}] - Client's average review: [{Client.GetAverageBall()}]";
        }
    }
}
