using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01
{
    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }

        public Address(string street)
        {
            Street = street;
        }

        public override string ToString()
        {
            return $"City: {City}, Street: {Street}";
        }
    }
}
