using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
        List<Location> fromLocationList = new List<Location>();
        List<Location> toLocationList = new List<Location>();
        readonly List<BusType> busTypesList = new List<BusType>();
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
            fromLocationList = context.Locations.ToList();
            toLocationList = context.Locations.ToList();
            busTypesList.Add(BusType.All);
            busTypesList.Add(BusType.Business);
            busTypesList.Add(BusType.Express);
            busTypesList.Add(BusType.Regular);

            fromCombobox.ItemsSource = fromLocationList;
            toCombobox.ItemsSource = toLocationList;
            busTypeCombobox.ItemsSource = busTypesList;
            searchListView.ItemsSource = displayings;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var date = rideDatePicker.SelectedDate;
            Location startPoint = fromCombobox.SelectedItem as Location;
            Location destinationPoint = toCombobox.SelectedItem as Location;
            //BusType busType = (BusType)Enum.Parse(typeof(BusType), (string)busTypeCombobox.SelectedValue);

            if (date == null)
            {
                MessageBox.Show("Please, choose a date");
                return;
            }

            var rides = context.Rides
                .Where(s => s.StartPoint.IdLocation == startPoint.IdLocation && s.DestinationPoint.IdLocation == destinationPoint.IdLocation)
                .Include("RideStops")
                .ToList();

            searchListView.ItemsSource = rides;

            int g = 0;
        }

        private void SearchListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (searchListView.SelectedItem is Ride selectedRide)
            {
                var dialog = new RideDetailsDialog(selectedRide);
                dialog.Show();
            }
        }

        public static void SearchDetailsChanged(Location startPoint, Location destinationPoint, DateTime selectedDate, BusType busType = BusType.All)
        {
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new RideDetailsDialog();
            dialog.Show();
        }
    }
}
