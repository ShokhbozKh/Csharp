using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    class DisplayingsBus
    {
        public int IdDisplaying { get; set; }
        public Bus Bus { get; set; }
        public Displaying Displaying { get; set; }
        public string Departure 
        {
            get => Displaying.RideSchedule.Schedule.DepartureTime.ToString("HH:mm");
        }
        public string Arrival 
        {
            get => Displaying.RideSchedule.Schedule.ArrivalTime.ToString("HH:mm");
        }
    }
}
