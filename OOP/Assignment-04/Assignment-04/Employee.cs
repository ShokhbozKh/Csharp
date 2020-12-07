using System;

namespace Assignment_04
{
    [Serializable]
    abstract class Employee : User // Disjoint
    {
        public Position Position { get; set; }
        public static int TaxRate { get; set; }
        public WorkMode WorkMode { get; set; }

        #region Constructors
        public Employee(string login, string password, Position position) : base(login, password)
        {
            Position = position;
        }

        public Employee(string login, string password, string firstName, string lastName, Position position) 
            : base(login, password, firstName, lastName)
        {
            Position = position;
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

        public override string ToString()
        {
            return $"{base.ToString()}, Position: [{Position}]";
        }
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
