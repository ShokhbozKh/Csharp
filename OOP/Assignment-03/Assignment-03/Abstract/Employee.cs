using System;
using System.Collections.Generic;

namespace Assignment_03
{
    [Serializable]
    abstract partial class Employee : User
    {
        #region Properties

        public static decimal _taxRate;
        public static decimal TaxRate 
        {
            get => _taxRate;
            set => _taxRate = value;
        }

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

        public List<Position> Positions { get; private set; } = new List<Position>();

        #endregion

        #region Constructors
        // Driver
        public Employee(string login, string password)
            : base(login, password)
        {
        }

        public Employee(string login, string password, string firstName, string lastName, Car car = null)
            : base(login, password, firstName, lastName)
        {
            _car = car;

            Positions.Add(Position.Driver);
        }
       
        // Customer Support
        public Employee(string login, string password, string firstName, string lastName)
            : base(login, password, firstName, lastName)
        {

            Positions.Add(Position.CustomerSupport);
        }

        #endregion;

        #region Methods

        public abstract decimal GetIncome();

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
