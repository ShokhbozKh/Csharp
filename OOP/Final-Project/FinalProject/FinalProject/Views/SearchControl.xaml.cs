using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using FinalProject.DAL;
using FinalProject.Models;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        private static DbService context;
        private static readonly ObservableCollection<DisplayingsBus> displayingss = new ObservableCollection<DisplayingsBus>();
        private static DisplayingsBus selectedItem;
        public SearchControl()
        {
            InitializeComponent();
            context = new DbService();

            searchListView.ItemsSource = displayingss;
/*
            var r = new DisplayingsBus().Displaying.RideSchedule.RideDate.Ride.StartPoint.StationName;
            var s = new DisplayingsBus().Displaying.RideSchedule.RideDate.Ride.DestinationPoint;
            var q = new DisplayingsBus().Displaying.RideSchedule.Schedule.DepartureTime;
            var a = new DisplayingsBus().Displaying.RideSchedule.Schedule.ArrivalTime;
            var p = new DisplayingsBus().Displaying.StandardPrice;
            var avs = new DisplayingsBus().Displaying.AvialableSeats;
            var t = new DisplayingsBus().Displaying.RideSchedule.RideDate.Ride.TotalHours;*/
        }

        public static void SearchDetailsChanged(string startPoint, string destinationPoint, DateTime selectedDate)
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var displaying = context.Displayings.Include("RideSchedule.Schedule").Include("RideSchedule.RideDate.Ride.StartPoint").ToList();
            var avs = context.AvialableSeats
                .Where(s => s.RideSchedule.RideDate.Ride.StartPoint.LocationName == startPoint
                        && s.RideSchedule.RideDate.Ride.DestinationPoint.LocationName == destinationPoint
                        && s.RideSchedule.RideDate.Date.Month == selectedDate.Month
                        && s.RideSchedule.RideDate.Date.Day == selectedDate.Day)
                .Select(s => new
                {
                    bus = s.Bus,
                    rideSchedule = s.RideScheduleId
                })
                .Distinct().ToList();

            var displayings = (from d in context.Displayings.ToList()
                               join av in avs on d.RideSchedule.IdRideSchedule equals av.rideSchedule
                               select new DisplayingsBus { Bus = av.bus, Displaying = d}).ToList();

            foreach (var d in displayings) displayingss.Add(d);

            int g = 0;
        }

        private void SearchListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = searchListView.SelectedItem as DisplayingsBus;
        }
    }
}
