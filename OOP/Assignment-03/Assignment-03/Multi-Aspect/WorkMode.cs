using System;

namespace Assignment_03
{
    abstract class WorkMode
    {
        public Employee Employee { get; private set; }
        private protected virtual decimal Bonus { get; set; }

        abstract public decimal CalculateMinimalPlan();
        abstract public decimal CalculateMonthlyTax();

        public static void AssignWorkMode(Employee employee, WorkMode workMode)
        {
            if (employee == null || workMode == null) throw new ArgumentNullException();

            employee.WorkMode = workMode;
            workMode.Employee = employee;
        }
    }
}
