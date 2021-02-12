using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
        private static readonly ObservableCollection<Displaying> displayings = new ObservableCollection<Displaying>();
        public SearchControl()
        {
            InitializeComponent();
            context = new DbService();

            searchListView.ItemsSource = displayings;
        }

        public static void SearchDetailsChanged(string startPoint, string destinationPoint, DateTime selectedDate)
        {
            var result = context.Displayings.Where(s => s.Ride.StartPoint.LocationName == startPoint && s.Ride.DestinationPoint.LocationName == destinationPoint)
                .Include(s => s.Bus)
                .Include(s => s.Ride)
                .Include(s => s.Ride.StartPoint).ToList();

            displayings.Clear();

            foreach (var displaying in result) displayings.Add(displaying);

            int g = 0;
        }


    }
}
