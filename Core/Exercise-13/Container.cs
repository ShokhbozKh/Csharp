using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_13
{
    class Container
    {
        Candy candy;
        private double maxLoadWeight;

        public Container(double maxLoadWeight)
        {
            this.maxLoadWeight = maxLoadWeight;
        }

        public void Load(Candy candy)
        {
            if (candy.GetWeight() > maxLoadWeight)
                Console.WriteLine("Candy is too heavy");
            else
                this.candy = candy;
        }
    }
}
