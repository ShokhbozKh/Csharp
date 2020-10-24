using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Exercise_13
{
    class Candy
    {
        string flavor;
        double wieght;

        public Candy(string flavor, double weight)
        {
            this.flavor = flavor;
            this.wieght = weight;
        }

        public void Show()
        {
            Console.WriteLine($"Flavor: [{flavor}], Weight: [{wieght}]");
        }
    }
}
