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
        readonly List<string> busTypesList = new List<string>();
        public RideDetailsControl()
        {
            InitializeComponent();
            LoadData();

            fromCombobox.ItemsSource = fromLocationList;
            toCombobox.ItemsSource = toLocationList;
            busTypeCombobox.ItemsSource = busTypesList;
            busTypeCombobox.SelectedIndex = 3;
        }

        void LoadData()
        {
            var context = new DbService();

            fromLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            toLocationList = context.Locations.Select(s => s.LocationName).Distinct().ToList();
            busTypesList.Add(BusType.All.ToString());
            busTypesList.Add(BusType.Business.ToString());
            busTypesList.Add(BusType.Express.ToString());
            busTypesList.Add(BusType.Regular.ToString());
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

            //int g = 0;

            if(date == null)
            {
                MessageBox.Show("Please, choose a date");
                return;
            }

            SearchControl.SearchDetailsChanged(fromCombobox.SelectedItem.ToString(), toCombobox.SelectedItem.ToString(), (DateTime)date, busType);
        }
    }

    public class ComboData
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
