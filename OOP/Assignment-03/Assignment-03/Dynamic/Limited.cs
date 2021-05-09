namespace Assignment_03.Dynamic
{
    class Limited
    {
        public decimal VAT { get; private set; }

        public Limited(decimal vat)
        {
            VAT = vat;
        }
    }
}
