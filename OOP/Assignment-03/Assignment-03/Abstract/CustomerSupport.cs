using System;

namespace Assignment_03
{
    class CustomerSupport : Employee
    {
        #region Properties

        // per hour
        private decimal _salary;
        public decimal Salary 
        {
            get => _salary;
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Salary of the employee cannot be negative!");
                    
                    return;
                }

                _salary = value;
            }
        }

        private decimal _workHours;
        public decimal WorkHours
        {
            get => _workHours;
            set
            {
                if(value < 0) throw new Exception("Work hours cannot be negative!");

                _workHours = value;
            }
        }

        #endregion

        #region Constructors
        public CustomerSupport(string login, string password, decimal salary)
            : base(login, password)
        {
            _salary = salary;
        }

        public CustomerSupport(string login, string password, string firstName, string lastName, decimal salary)
            : base(login, password, firstName, lastName)
        {
            _salary = salary;
        }

        #endregion

        public override decimal GetIncome()
        {
            return (Salary * WorkHours) - (TaxRate * Salary * WorkHours);
        }
    }
}
