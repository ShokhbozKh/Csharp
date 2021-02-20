using System;
using System.ComponentModel;

namespace FinalProject.Models
{
    public class RideSearchDetails : INotifyPropertyChanged
    {
        public string StartPoint { get; set; }
        public string DestinationPoint { get; set; }
        public BusType BusType { get; set; }
        public DateTime RideDate { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
