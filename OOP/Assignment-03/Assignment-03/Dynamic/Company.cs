using System;
using System.Collections.Generic;

namespace Assignment_03.Dynamic
{
    class Company
    {
        public string Name { get; private set; }
        public decimal Revenue { get; private set; }

        public List<Employee> Employees { get; private set; } = new List<Employee>();

        public Company(string name, decimal revenue)
        {
            Name = name;
            Revenue = revenue;
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException();

            if (Employees.Contains(employee)) throw new Exception($"The company {Name} already has given employee");

            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException();

            if (Employees.Contains(employee)) throw new Exception($"The company {Name} does not contain given employee");

            Employees.Remove(employee);
        }
    }
}
