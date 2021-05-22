using System;

namespace Assignment_03.Dynamic
{
    class Registered
    {
        public string GovernmentDepartment { get; set; }
        public DateTime RegisteredDate { get; set; }
        public Company Company { get; set; }

        private Registered(string governmentDepartment, DateTime registeredDate = new DateTime())
        {
            GovernmentDepartment = governmentDepartment;
            RegisteredDate = registeredDate;
        }

        public static Registered EstablishRegisteredCompany(Company company, string governmentDepartment, DateTime registeredDate = new DateTime())
        {
            if (company == null) throw new ArgumentNullException("Company cannot be null!");
            if (string.IsNullOrEmpty(governmentDepartment)) throw new ArgumentNullException("Organization for Civil company cannot be null!");

            Registered registered = new Registered(governmentDepartment, registeredDate)
            {
                Company = company
            };

            company.RegisterRegisteredCompany(registered);

            return registered;
        }

        public override string ToString()
        {
            return $"Department: [{GovernmentDepartment}], RegisteredDate: [{RegisteredDate}], {Company}";
        }
    }
}
