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
        List<string> fromLocationList = new List<string>();
        List<string> toLocationList = new List<string>();
        readonly List<string> busTypesList = new List<string>();
        private static DbService context;

        public RideDetailsDialog()
        {
            InitializeComponent();
            context = new DbService();
            LoadData();
        }

        public RideDetailsDialog(DisplayingsBus displaying)
        {
            InitializeComponent();
            context = new DbService();
            LoadData();
            priceTextbox.Text = displaying.Displaying.StandardPrice.ToString();
        }

        void LoadData()
        {
            fromLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            toLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            busTypesList.Add(BusType.All.ToString());
            busTypesList.Add(BusType.Business.ToString());
            busTypesList.Add(BusType.Express.ToString());
            busTypesList.Add(BusType.Regular.ToString());

            startPointCombobox.ItemsSource = fromLocationList;
            destinationPointCombobox.ItemsSource = toLocationList;
            busTypeCombobox.ItemsSource = busTypesList;
            stopsListbox.ItemsSource = fromLocationList;
        }

        private void AddRide_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
