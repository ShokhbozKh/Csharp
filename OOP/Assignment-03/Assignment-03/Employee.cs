using System;

namespace Assignment_03
{
    [Serializable]
    abstract class Employee : User // Disjoint
    {
        public Position Position { get; set; }

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

    }

    enum Position
    {
        CustomerSupport,
        Analyst,
        ProductDesign,
        Driver
    }

}
