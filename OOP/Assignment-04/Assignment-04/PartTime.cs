using System;

namespace Assignment_04
{
    class PartTime : WorkMode
    {
        public int MinHours { get; set; } // Minimal hours plan to complete monthly

        public PartTime(int minHourse)
        {
            MinHours = minHourse;
        }

        public override decimal CalculateMinimalPlan()
        {
            return MinHours;
        }
    }
}
