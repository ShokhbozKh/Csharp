using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for RideDetailsControl.xaml
    /// </summary>
    public partial class RideDetailsControl : UserControl
    {
        List<string> fromLocationList = new List<string>();
        List<string> toLocationList = new List<string>();
        List<string> busTypesList = new List<string>();
        public RideDetailsControl()
        {
            InitializeComponent();
            LoadData();

            fromCombobox.ItemsSource = fromLocationList;
            toCombobox.ItemsSource = toLocationList;
            busTypeCombobox.ItemsSource = busTypesList;
        }

        void LoadData()
        {
            var context = new DbService();

            fromLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            toLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            busTypesList.Add(BusType.Business.ToString());
            busTypesList.Add(BusType.Express.ToString());
            busTypesList.Add(BusType.Regular.ToString());

            /*fromLocationList.Add("Warsaw");
            fromLocationList.Add("Gdansk");
            fromLocationList.Add("Krakow");
            fromLocationList.Add("Wroclaw");

            toLocationList.Add("Warsaw");
            toLocationList.Add("Gdansk");
            toLocationList.Add("Krakow");
            toLocationList.Add("Wroclaw");*/



            /*busTypesList.Add("Standard");
            busTypesList.Add("Econom");
            busTypesList.Add("Business");
            busTypesList.Add("Express");*/

            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = (DateTime)rideDatePicker.SelectedDate;

            SearchControl.SearchDetailsChanged(fromCombobox.SelectedItem.ToString(), toCombobox.SelectedItem.ToString(), date);
        }
    }

    public class ComboData
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
