using System;

namespace Assignment_03.Dynamic
{
    class Limited
    {
        public decimal VAT { get; private set; }
        public double Stock { get; private set; }
        public Company Company { get; set; }

        private Limited(decimal vat, double stock)
        {
            VAT = vat;
            Stock = stock;
        }

        public static Limited EstablishLimitedCompany(Company company, decimal vat, double stock)
        {
            if (company == null) throw new ArgumentNullException("Company cannot be null!");
            if (vat < 0) throw new ArgumentException("VAT for limited company cannot be negative");
            if (stock < 0) throw new ArgumentException("Stock for limited company cannot be negative");

            Limited limited = new Limited(vat, stock)
            {
                Company = company
            };

            company.RegisterLimitedCompany(limited);

            return limited;
        }

        public override string ToString()
        {
            return $"Stock: [{Stock}], VAT: [{VAT}], {Company}";
        }
    }
}
