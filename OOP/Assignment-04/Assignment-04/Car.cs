using System;

namespace Assignment_04
{
    [Serializable]
    class Car : ObjectPlus
    {
        public Guid IdCar { get; private set; }
        public string CarNumber { get; private set; }
        public string Brand { get; private set; }
        public Category Category { get; private set; }
        private static decimal _maxPrice;
        public static decimal MAX_PRICE 
        {
            get => _maxPrice;
            set
            {
                if(value > 0)
                {
                    Console.WriteLine("Max price cannot be negative");

                    return;
                }

                _maxPrice = value;
            }
        }
        private decimal _price; // per km
        public decimal Price 
        {
            get => _price;
            set
            {
                if(value > 0 && value < MAX_PRICE)
                {
                    Console.WriteLine("Price for per km should be non-negative and less than max price!");
                    
                    return;
                }

                _price = value;
            }
        }

        private Driver _driver;
        public Driver Driver 
        { 
            get => _driver;
            set
            {
                if(_driver == null && value != null)
                {
                    _driver = value;
                    _driver.AddCar(this);
                }
                else if(_driver != null && value == null)
                {
                    _driver.RemoveCar(this);
                    _driver = value;
                }
                else if(_driver != null && value != null && _driver != value)
                {
                    _driver.RemoveCar(this);
                    _driver = value;
                    _driver.AddCar(this);
                }
            }
        }

        #region constructors
        public Car(string carNumber, string brand, Category category)
        {
            IdCar = Guid.NewGuid();
            CarNumber = carNumber;
            Brand = brand;
            Category = category;
        }

        public Car(string carNumber, string brand, decimal price, Category category)
        {
            IdCar = Guid.NewGuid();
            CarNumber = carNumber;
            Brand = brand;
            Category = category;
            Price = price;
        }

        #endregion

        public override string ToString()
        {
            return $"Brand: [{Brand}], Car number: [{CarNumber}], Driver: [{Driver?.Login}], Category: [{Category}], Price per km: [{Price}]";
        }
    }

    enum Category
    {
        Lux,
        Bussiness,
        Economy
    }
}
