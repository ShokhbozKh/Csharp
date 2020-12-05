using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    class FullTime : WorkMode
    {
        public FullTime(string login, string password, Position position)
            : base(login, password, position)
        {
        }

        public override decimal CalculateMinimalPlan()
        {
            throw new NotImplementedException();
        }

        internal override decimal GetIncome()
        {
            throw new NotImplementedException();
        }

        public void GetContract()
        {
            throw new NotImplementedException();
        }
    }
}
