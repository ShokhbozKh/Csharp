namespace Assignment_03
{
    class PartTime : WorkMode
    {
        public decimal TaxRate { get; set; }
        
        public PartTime()
        {
            TaxRate = 7.5m;
        }

        public PartTime(decimal taxRate)
        {
            TaxRate = taxRate;
        }

        public override decimal CalculateMinimalPlan()
        {
            return 20;
        }

        public override decimal CalculateMonthlyTax()
        {
            return TaxRate;
        }
    }
}
