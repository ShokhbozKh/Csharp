using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for RidesControl.xaml
    /// </summary>
    public partial class RidesControl : UserControl
    {
        List<string> fromLocationList = new List<string>();
        List<string> toLocationList = new List<string>();
        readonly List<string> busTypesList = new List<string>();
        private static DbService context;
        public static readonly ObservableCollection<DisplayingsBus> displayings = new ObservableCollection<DisplayingsBus>();
        public RidesControl()
        {
            InitializeComponent();
            context = new DbService();
            LoadData();
        }

        void LoadData()
        {
            fromLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            toLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            busTypesList.Add(BusType.All.ToString());
            busTypesList.Add(BusType.Business.ToString());
            busTypesList.Add(BusType.Express.ToString());
            busTypesList.Add(BusType.Regular.ToString());

            fromCombobox.ItemsSource = fromLocationList;
            toCombobox.ItemsSource = toLocationList;
            busTypeCombobox.ItemsSource = busTypesList;
            searchListView.ItemsSource = displayings;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var date = rideDatePicker.SelectedDate;
            BusType busType;

            switch (busTypeCombobox.SelectedItem.ToString())
            {
                case "All":
                    busType = BusType.All;
                    break;
                case "Business":
                    busType = BusType.Business;
                    break;
                case "Express":
                    busType = BusType.Express;
                    break;
                case "Regular":
                    busType = BusType.Regular;
                    break;
                default:
                    busType = BusType.All;
                    break;
            }

            if (date == null)
            {
                MessageBox.Show("Please, choose a date");
                return;
            }

            SearchDetailsChanged(fromCombobox.SelectedItem.ToString(), toCombobox.SelectedItem.ToString(), (DateTime)date, busType);
        }

        private void SearchListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRide = searchListView.SelectedItem as DisplayingsBus;

            if(selectedRide != null)
            {
                var dialog = new RideDetailsDialog(selectedRide);
                dialog.Show();
            }
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
            if (busType != BusType.All)
            {
                avs = avs.Where(s => s.bus.BusType == busType).ToList();
            }

            // Make a list from concateneted avialableSeats and displayings tables
            var displayingsBus = (from d in context.Displayings.Include("RideSchedule").ToList()
                                  join av in avs on d.RideSchedule.IdRideSchedule equals av.rideSchedule
                                  select new DisplayingsBus { Bus = av.bus, Displaying = d }).ToList();

            foreach (var d in displayingsBus)
            {
                displayings.Add(d);
            }
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new RideDetailsDialog();
            dialog.Show();

        }
    }
}
