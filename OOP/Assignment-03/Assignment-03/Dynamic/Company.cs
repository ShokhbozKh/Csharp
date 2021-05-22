using System;
using System.Collections.Generic;

namespace Assignment_03.Dynamic
{
    class Company
    {
        public string Name { get; private set; }
        public decimal Revenue { get; private set; }
        public List<Employee> Employees { get; private set; } = new List<Employee>();

        private Civil _civil;
        private Limited _limited;
        private Registered _registered;

        public Civil Civil 
        {
            get => _civil;
            private set
            {
                if(Limited != null)
                {
                    Limited = null;
                }
                else if(Registered != null)
                {
                    Registered = null;
                }

                _civil = null;
            }
        }
        public Limited Limited 
        {
            get => _limited;
            private set
            {
                if(Civil != null)
                {
                    Civil = null;
                }
                else if(Registered != null)
                {
                    Registered = null;
                }

                _limited = value;
            }
        }
        public Registered Registered 
        {
            get => _registered;
            private set
            {
                if(Civil != null)
                {
                    Civil = null;
                }
                else if(Limited != null)
                {
                    Limited = null;
                }

                _registered = value;
            }
        }

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

        public void RegisterCivilCompany(Civil civil)
        {
            if (civil is null) throw new ArgumentNullException("Civil company cannot be null!");

            if (Civil != null) return;

            Civil = civil;
        }

        public void RegisterLimitedCompany(Limited limited)
        {
            if (limited is null) throw new ArgumentNullException("Limited company cannot be null!");

            if (Limited != null) return;
            Limited = limited;
        }

        public void RegisterRegisteredCompany(Registered registered)
        {
            if (registered is null) throw new ArgumentNullException("Registered company cannot be null!");

            if (Registered != null) return;

            Registered = registered;
        }

        public Civil TransformToCivil(string organization)
        {
            if (string.IsNullOrEmpty(organization)) throw new ArgumentNullException("Organization for civil company cannot be nulL!");

            Civil civil = Civil.EstablishCivilCompany(this, organization);

            Civil = civil;

            return Civil;
        }

        public Registered TransformToRegistered(string governmentDepartment)
        {
            if (string.IsNullOrEmpty(governmentDepartment)) throw new ArgumentNullException("Organization for Civil company cannot be null!");

            Registered registered = Registered.EstablishRegisteredCompany(this, governmentDepartment);

            Registered = registered;

            return registered;
        }

        public Limited TransformToLimited(decimal vat, double stock)
        {
            if (vat < 0) throw new ArgumentException("VAT for limited company cannot be negative");
            if (stock < 0) throw new ArgumentException("Stock for limited company cannot be negative");

            Limited limited = Limited.EstablishLimitedCompany(this, vat, stock);

            Limited = limited;

            return limited;
        }

        public override string ToString()
        {
            return $"Company name: [{Name}], Revenue: [{Revenue}]";
        }
    }

    enum CompanyType
    {
        Civil,
        Registered,
        Limited
    }
}
