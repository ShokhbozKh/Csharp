using System;
using System.Collections.ObjectModel;
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
        private static readonly ObservableCollection<Displaying> displayings = new ObservableCollection<Displaying>();
        public SearchControl()
        {
            InitializeComponent();
            context = new DbService();

            searchListView.ItemsSource = displayings;
        }

        public static void SearchDetailsChanged(string startPoint, string destinationPoint, DateTime selectedDate)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var date = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
            var result = context.Displayings
                .Where(s => s.RideSchedule.RideDate.Date == date
                        && s.RideSchedule.RideDate.Ride.DestinationPoint.LocationName == destinationPoint
                        && s.RideSchedule.RideDate.Ride.StartPoint.LocationName == startPoint).ToList();

            displayings.Clear();

            foreach (var r in result) displayings.Add(r);

            int g = 0;
        }

    }
}
