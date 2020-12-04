using System;

namespace Assignment_03
{
    [Serializable]
    abstract class Employee : User // Disjoint
    {
        public Position Position { get; set; }
        private static int _taxRate = 1;
        public static int TaxRate
        {
            get => _taxRate;
            set
            {
                if (value < 0 && value >= 100)
                {
                    Console.WriteLine("Tax rate must be between 1 and 99 %");

                    return;
                }

                _taxRate = value;
            }
        }

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

        #region Overrides

        public override string ToString()
        {
            return $"{base.ToString()} Position: {Position}";
        }
        #endregion

        #region Methods

        internal abstract decimal GetIncome();

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
