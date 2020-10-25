using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Exercise_16
{
    internal class Purchase : IComparer<Purchase>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Purchase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }


        public int Compare([AllowNull] Purchase x, [AllowNull] Purchase y)
        {
            if (x.Name.CompareTo(y.Name) == 0)
                return 0;
            else if (x.Name.CompareTo(y.Name) > 0)
                return 1;
            else
                return -1;
        }
    }
}
