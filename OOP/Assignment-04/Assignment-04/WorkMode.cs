using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_04
{
    abstract class WorkMode
    {
        abstract public decimal CalculateMinimalPlan();
        private protected decimal Bonus { get; set; }

        public WorkMode()
        {
        }

    }
}
