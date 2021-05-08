using System;
using System.Collections.Generic;

namespace Assignment_03
{
    [Serializable]
    abstract class Employee : User
    {
        public static int TaxRate { get; private set; }

        private Car _car;
        public Car Car 
        {
            get
            {
                if (!Positions.Contains(Position.Driver))
                {
                    throw new Exception("This employee is not a driver");
                }

                return _car;
            }
            set
            {
                if (!Positions.Contains(Position.Driver))
                {
                    throw new Exception("This employee is not a driver");
                }

                _car = value;
            }
        }

        private double _workHours;
        public double WorkHours 
        {
            get
            {
                if (!Positions.Contains(Position.CustomerSupport))
                {
                    throw new Exception("This employee is not a custom support");
                }

                return _workHours;
            }
            set
            {
                if (!Positions.Contains(Position.CustomerSupport))
                {
                    throw new Exception("This employee is not a customer support");
                }

                _workHours = value;
            }
        }

        public List<Position> Positions { get; private set; }


        #region Constructors
        // Driver
        public Employee(string login, string password, string firstName, string lastName, Car car)
            : base(login, password, firstName, lastName)
        {
            _car = car;

            Positions.Add(Position.Driver);
        }
       
        // Customer
        public Employee(string login, string password, string firstName, string lastName, double workHours)
            : base(login, password, firstName, lastName)
        {
            _workHours = workHours;

            Positions.Add(Position.CustomerSupport);
        }

        public Employee(string login, string password, string firstName, string lastName, Car car, double workHours)
            : base(login, password, firstName, lastName)
        {
            _car = car;
            _workHours = workHours;

            Positions.Add(Position.Driver);
            Positions.Add(Position.CustomerSupport);
        }

        #endregion;

        #region Methods

        internal abstract decimal GetIncome();

        public Driver MakeDriver()
        {
            if (this is CustomerSupport)
            {
                return new Driver(Login, Password, FirstName, LastName);                
            }
            else
            {
                Console.WriteLine("Cannot be converted to Driver!");
                
                return null;
            }
        }

        public CustomerSupport MakeCustomerSupport(decimal Salary)
        {
            if(this is Driver)
            {
                return new CustomerSupport(Login, Password, Salary);
            }
            else
            {
                Console.WriteLine("Cannot be converted to Customer Support!");

                return null;
            }
        }

        #endregion

        #region Overrides

        public override string ToString() => $"{FirstName} {LastName}";
        #endregion
    }

    enum Position
    {
        CustomerSupport,
        Analyst,
        ProductDesign,
        Driver
    }

}
