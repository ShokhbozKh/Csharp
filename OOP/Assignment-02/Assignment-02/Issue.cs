using System;

namespace Assignment_02
{
    class Issue
    {
        public string Description { get; set; }
        public bool IsClosed { get; set; }
        public Ride Ride { get; private set; }

        private Issue(Ride ride, string description)
        {
            Ride = ride;
            Description = description;
            IsClosed = false;
        }

        public static Issue ReportIssue(Ride ride, string description)
        {
            if (ride == null) throw new Exception("Ride cannot be null!");
            if (string.IsNullOrEmpty(description)) throw new Exception("Please, provide valid description");

            Issue newIssue = new Issue(ride, description);

            ride.AddIssue(newIssue);

            return newIssue;
        }

    }
}
