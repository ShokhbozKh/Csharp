using System;

namespace Assignment_03
{
    class FullTime : WorkMode
    {
        public FullTime()
        {
        }

        public override decimal CalculateMinimalPlan()
        {
            if (Employee.Positions.Contains(Position.Driver))
            {
                return 0;
            }
            else
            {
                return 35;
            }
        }

        public override decimal CalculateMonthlyTax()
        {
            if (Employee.Positions.Contains(Position.Driver))
            {
                decimal totalsum = 0;

                foreach(Ride ride in (Employee as Driver).Rides)
                {
                    totalsum += ride.TotalPrice;
                }

                return totalsum - (Employee.TaxRate * totalsum);
            }
            else
            {
                decimal tax = (Employee.TaxRate * (Employee as CustomerSupport).Salary);

                return (Employee as CustomerSupport).Salary - tax;
            }
        }

        public void GetContract()
        {
            throw new NotImplementedException();
        }
    }
}
