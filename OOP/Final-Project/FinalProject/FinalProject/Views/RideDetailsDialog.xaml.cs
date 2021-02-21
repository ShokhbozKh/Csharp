using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for RideDetailsDialog.xaml
    /// </summary>
    public partial class RideDetailsDialog : Window
    {
        List<Location> fromLocationList = new List<Location>();
        List<Location> toLocationList = new List<Location>();
        readonly List<BusType> busTypesList = new List<BusType>();
        private static DbService context;

        public RideDetailsDialog()
        {
            InitializeComponent();
            context = new DbService();
            LoadData();
        }

        public RideDetailsDialog(Ride ride)
        {
            InitializeComponent();
            context = new DbService();
            LoadData();

            fromLocationList.ForEach(el =>
            {
                if (el.IdLocation == ride.StartPoint.IdLocation) startPointCombobox.SelectedItem = el;
                else if (el.IdLocation == ride.DestinationPoint.IdLocation) destinationPointCombobox.SelectedItem = el;
            });
            
            for(int i = 0; i < ride.RideStops.ToList().Count; i++)
            {
                if (stopsListbox.Items.GetItemAt(i) == ride.RideStops.ElementAt(i)) stopsListbox.SelectedItems.Add(ride.RideStops.ElementAt(i));
            }

            int g = 0;
        }

        void LoadData()
        {
            fromLocationList = context.Locations.ToList();
            toLocationList = context.Locations.ToList();
            busTypesList.Add(BusType.All);
            busTypesList.Add(BusType.Business);
            busTypesList.Add(BusType.Express);
            busTypesList.Add(BusType.Regular);

            startPointCombobox.ItemsSource = fromLocationList;
            destinationPointCombobox.ItemsSource = toLocationList;
            busTypeCombobox.ItemsSource = busTypesList;
            stopsListbox.ItemsSource = fromLocationList;
        }

        private void AddRide_Click(object sender, RoutedEventArgs e)
        {
            var context = new DbService();

            Location fromLocation = startPointCombobox.SelectedItem as Location;
            Location toLocation = destinationPointCombobox.SelectedItem as Location;
            BusType busType = (BusType)Enum.Parse(typeof(BusType), (string)busTypeCombobox.SelectedValue);
            List<Location> stops = new List<Location>();

            for (int i = 0; i < stopsListbox.SelectedItems.Count; i++)
            {
                stops.Add(stopsListbox.SelectedItems[i] as Location);
            }

            Ride newRide = new Ride()
            {
                StartPoint = fromLocation,
                DestinationPoint = toLocation,
                TotalHours = 8
            };
            
            context.Rides.Add(newRide);
            
            foreach(Location stop in stops)
            {
                context.RideStops.Add(new RideStop()
                {
                    Ride = newRide,
                    Location = stop
                });
            }

            context.SaveChanges();

            int g = 0;
        }
    }
}
