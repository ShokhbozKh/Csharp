using System;

namespace Assignment_03
{
    [Serializable]
    class Car : ObjectPlus
    {
        public Guid IdCar { get; private set; }
        public string CarNumber { get; private set; }
        public string Brand { get; private set; }
        public Category Category { get; private set; }
        public decimal Price { get; private set; }  // per km

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
            return $"Brand: [{Brand}], Car number: [{CarNumber}], Driver: [{Driver.Login}], Category: [{Category}]";
        }
    }

    enum Category
    {
        Lux,
        Bussiness,
        Economy
    }
}
