using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_04
{
    class Contractor
    {
        private Guid IdContractor { get; set; }
        private string ContractorName { get; set; }
        private string ContractorAddress { get; set; }
        private decimal PriceForCar { get; set; } // monthly

        private readonly ICollection<Car> _cars;

        public Contractor(string contractorName, string contractorAddress, decimal priceForCar)
        {
            IdContractor = Guid.NewGuid();
            ContractorName = contractorName;
            ContractorAddress = contractorAddress;
            PriceForCar = priceForCar;

            _cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            if (car is null)
                throw new NullReferenceException("The given car is null!");

            if(_cars.Contains(car))
            {
                Console.WriteLine("The contractor already has the given car!");

                return;
            }

            _cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            if(car is null)
                throw new NullReferenceException("The given car is null!");

            if(_cars.Contains(car))
            {
                _cars.Remove(car);

                return;
            }

            Console.WriteLine("The contractor does not contain the given car!");
        }

        public void ShowCars()
        {
            Console.WriteLine($"Contractor {ContractorName}'s cars:");

            foreach(Car car in _cars)
                Console.WriteLine(car);
        }

        public override string ToString()
        {
            return $"Contractor: [{ContractorName}], Price for car monthly: [{PriceForCar}], Address: [{ContractorAddress}]";
        }
    }
}
