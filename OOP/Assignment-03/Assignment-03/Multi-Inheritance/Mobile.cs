using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03.Multi_Inheritance
{
    class Mobile : IMobile
    {
        public int PhoneId { get; set; }
        public string SimcardNumber { get; set; }
        public decimal Price { get; set; }

        public string GetSimcardNumber()
        {
            if (!string.IsNullOrEmpty(SimcardNumber))
            {
                return SimcardNumber;
            }

            else
            {
                throw new Exception("This phone does not have simcard number");
            }
        }

        public void MakeCall(string number)
        {
            if (!string.IsNullOrEmpty(number))
            {
                Console.WriteLine($"calling to the number: {number}");
            }
        }
    }
}
