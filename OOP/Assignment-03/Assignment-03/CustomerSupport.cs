using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    class CustomerSupport : Employee
    {
        public int TaxRate { get; set; }

        private decimal _salary;
        public decimal Salary 
        {
            get => _salary;
            set => _salary = value;
        }

        #region Constructors
        public CustomerSupport(string login, string password)
            : base(login, password, Position.CustomerSupport)
        {
        }

        public CustomerSupport(string login, string password, string firstName, string lastName)
            : base(login, password, firstName, lastName, Position.CustomerSupport)
        {
        }

        #endregion

        internal override decimal GetIncome()
        {
            return Salary - ((Salary * TaxRate) / 100);
        }
    }
}
