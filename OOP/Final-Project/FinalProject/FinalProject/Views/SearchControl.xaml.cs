using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        public static readonly ObservableCollection<DisplayingsBus> displayings = new ObservableCollection<DisplayingsBus>();

        public static Displaying SelectedRide { get; set; }
        public Button NextButton { get; set; }        

        public SearchControl(ref Button nextButton)
        {
            InitializeComponent();
            context = new DbService();

            NextButton = nextButton;
            NextButton.IsEnabled = false;
            RideDetailsControl.SetButton(ref nextButton);
            searchListView.ItemsSource = displayings;
        }

        public static void SearchDetailsChanged(string startPoint, string destinationPoint, DateTime selectedDate, BusType busType = BusType.All)
        {
            // Clear collection from previous search
            displayings.Clear();

            var display = context.Displayings.Include("RideSchedule.RideDate.Ride.StartPoint").Include("RideSchedule.Schedule").ToList();            

            // Get distinct ride schedule by passed details
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

            // Filter by bus type
            if(busType != BusType.All)
            {
                avs = avs.Where(s => s.bus.BusType == busType).ToList();
            }

            // Make a list from concateneted avialableSeats and displayings tables
            var displayingsBus = (from d in context.Displayings.Include("RideSchedule").ToList()
                               join av in avs on d.RideSchedule.IdRideSchedule equals av.rideSchedule
                               select new DisplayingsBus { Bus = av.bus, Displaying = d}).ToList();
            
            foreach (var d in displayingsBus)
            {
                displayings.Add(d);
                
            }

            // reset selected ride
            SelectedRide = null;
        }

        private void SearchListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRide = ((sender as ListView).SelectedItem as DisplayingsBus)?.Displaying;

            if(SelectedRide != null) NextButton.IsEnabled = true;
        }
    }
}
