using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    abstract class WorkMode : Employee
    {
        abstract public decimal CalculateMinimalPlan();
        private protected decimal Bonus { get; set; }

        public WorkMode(string login, string password, Position position)
            : base(login, password, position)
        {
        }

    }
}
