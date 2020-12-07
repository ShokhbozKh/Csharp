using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_04
{
    class CustomerSupport : Employee
    {
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

        #region Constructors
        public CustomerSupport(string login, string password, decimal salary)
            : base(login, password, Position.CustomerSupport)
        {
            _salary = salary;
        }

        public CustomerSupport(string login, string password, string firstName, string lastName, decimal salary)
            : base(login, password, firstName, lastName, Position.CustomerSupport)
        {
            _salary = salary;
        }

        #endregion

        internal override decimal GetIncome()
        {
            return Salary - ((Salary * TaxRate) / 100);
        }
    }
}
