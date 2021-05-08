using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03.Multi_Inheritance
{
    class Computer
    {
        public int RAM { get; set; }
        public double Processor { get; set; }

        public Computer(int ram, double processor)
        {
            RAM = ram;
            Processor = processor;
        }

        public virtual double CalculateSpeed() => RAM + Processor;

        public void OpenApplication(string app)
        {
            Console.WriteLine("openning application");
        }

        public virtual void ConnectToInternet()
        {
            try
            {
                Console.WriteLine("Connect to internet");
            }
            finally
            {

            }
        }
    }
}
