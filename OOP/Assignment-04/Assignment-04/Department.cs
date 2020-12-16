using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Assignment_04
{
    class Department
    {
        public Guid IdDepartment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private readonly ICollection<Employee> _employees;
        public ICollection<Employee> Employees => _employees.ToImmutableList();

        public Department(string title, string description)
        {
            Title = title;
            Description = description;

            _employees = new HashSet<Employee>();
        }

        public Decimal GetRevenue()
        {
            // Yearly revenue of the current department
            decimal total = _employees.Sum(s => s.GetIncome()) * 12;

            decimal revenue = total - ((Employee.TaxRate * total) / 100);

            return revenue;
        }
    }
}
