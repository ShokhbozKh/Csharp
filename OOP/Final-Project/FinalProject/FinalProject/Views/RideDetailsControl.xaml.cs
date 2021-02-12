using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for RideDetailsControl.xaml
    /// </summary>
    public partial class RideDetailsControl : UserControl
    {
        readonly List<string> fromLocationList = new List<string>();
        readonly List<string> toLocationList = new List<string>();
        readonly List<string> busTypesList = new List<string>();
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
            fromLocationList.Add("Warsaw");
            fromLocationList.Add("Gdansk");
            fromLocationList.Add("Krakow");
            fromLocationList.Add("Wroclaw");

            toLocationList.Add("Warsaw");
            toLocationList.Add("Gdansk");
            toLocationList.Add("Krakow");
            toLocationList.Add("Wroclaw");

            busTypesList.Add("Standard");
            busTypesList.Add("Econom");
            busTypesList.Add("Business");
            busTypesList.Add("Express");
        }

        private void SearchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Clicked");
            SearchControl.SearchDetailsChanged("Warsaw", "Gdansk", DateTime.Now);
        }
    }
}
