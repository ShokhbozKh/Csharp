using System;

namespace Assignment_02
{
    [Serializable]
    class Car : ObjectPlus
    {
        public int IdCar { get; set; }
        public string CarNumber { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }

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

        public Car(string carNumber, string brand, Category category)
        {
            CarNumber = carNumber;
            Brand = brand;
            Category = category;
        }

        public override string ToString()
        {
            return $"Brand: [{Brand}], Car number: [{CarNumber}], Driver: [{Driver.Login}, Category: [{Category}]";
        }
    }

    enum Category
    {
        Lux,
        Bussiness,
        Economy
    }
}
