using System;

namespace Assignment_03.Dynamic
{
    class Civil
    {
        public Company Company { get; set; }
        public string Organization { get; set; }

        private Civil(string organization)
        {
            Organization = organization;
        }

        public static Civil EstablishCivilCompany(Company company, string organization)
        {
            if (company == null) throw new ArgumentNullException("Company cannot be null!");
            if (string.IsNullOrEmpty(organization)) throw new ArgumentNullException("Organization for Civil company cannot be null!");

            Civil civil = new Civil(organization)
            {
                Company = company
            };

            company.RegisterCivilCompany(civil);

            return civil;
        }

        public override string ToString()
        {
            return $"Organization: [{Organization}], {Company}";
        }
    }
}
