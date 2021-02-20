using FinalProject.DAL;
using FinalProject.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for SeatingArea.xaml
    /// </summary>
    public partial class SeatingArea : UserControl
    {
        public ObservableCollection<SeatModel> Seats { get; set; }
        public int SelectedSeatsCount { get; set; } = 0;
        public int RideScheduleId { get; set; }
        private readonly DbService context;
        public static List<int> SelectedSeats { get; set; } = new List<int>();

        public SeatingArea(int rideScheduleId)
        {
            RideScheduleId = rideScheduleId;
            context = new DbService();
            LoadData();
            InitializeComponent();
        }

        void LoadData()
        {
            int g = 0;
            /*Seats = new ObservableCollection<int>();

            for (int i = 0; i < 20; i++) Seats.Add(i);*/

            var avs = context.AvialableSeats.Where(s => s.RideScheduleId == RideScheduleId).ToList();
            avs[0].IsAvialable = false;
            avs[10].IsAvialable = false;
            avs[11].IsAvialable = false;
            Seats = new ObservableCollection<SeatModel>();

            avs.ForEach(el => Seats.Add(new SeatModel()
            {
                IdSeat = el.SeatId,
                IsAvialable = el.IsAvialable
            }));
        }

        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            SeatModel seat = btn.DataContext as SeatModel;

            if (seat.IsAvialable)
            {
                if (seat.Background == "Yellow")
                {
                    SelectedSeatsCount--;
                    SelectedSeats.Remove(seat.IdSeat);
                }
                else
                {
                    SelectedSeatsCount++;
                    SelectedSeats.Add(seat.IdSeat);
                }
                seat.Background = "Yellow";
            }

            SeatsNumber.Text = SelectedSeatsCount.ToString();

            int g = 0;
        }
    }
}
