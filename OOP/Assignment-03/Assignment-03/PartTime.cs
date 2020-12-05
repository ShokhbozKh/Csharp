using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    class PartTime : WorkMode
    {
        public int MinHours { get; set; } // Minimal hours plan to complete monthly

        public PartTime(string login, string password, Position position)
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
    }
}
