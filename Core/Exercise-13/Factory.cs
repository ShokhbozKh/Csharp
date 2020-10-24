using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_13
{
    class Factory
    {
        public static Dictionary<int, Candy> candies = new Dictionary<int, Candy>();
        public static Candy Make(int candyId)
        {
            candies[candyId] = candyId switch
            {
                0 => new Candy("Mint", 4.4),
                1 => new Candy("Chocolate", 5.2),
                2 => new Candy("Orange", 2.2),
                3 => new Candy("Marmelad", 3.7),
                _ => new Candy("Sweet", 4.2),
            };

            return candies[candyId];
        }
    }
}
