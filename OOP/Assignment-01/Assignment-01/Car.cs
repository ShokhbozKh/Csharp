using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01
{
    [Serializable]
    class Car : ObjectPlus
    {
        public int IdCar { get; set; }
        public string CarNumber { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }

        public Car(string carNumber, string brand,Category category)
        {
            this.carNumber = carNumber;
            this.brand = brand;
            this.category = category;
        }
    }

    enum Category
    {
        Lux,
        Bussiness,
        Economy
    }
}
