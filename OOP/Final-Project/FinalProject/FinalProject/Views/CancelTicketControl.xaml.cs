using FinalProject.DAL;
using FinalProject.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for CancelTicketControl.xaml
    /// </summary>
    public partial class CancelTicketControl : UserControl
    {
        public CancelTicketControl()
        {
            InitializeComponent();
        }

        private void TicketsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedTicket = ticketsListView.SelectedItem as TicketDisplay;

            var s = selectedTicket.Seats;

            int g = 0;

            if(selectedTicket != null)
            {
                var dialog = new TicketDetailsDialog(selectedTicket);
                dialog.Show();
            }
        }

        private void SearchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var context = new DbService();
            /*var ticket = context.Tickets.Where(s => s.TicketNumber == "c287b748-9eb5-41f8-b007-9cf248ee09fd").Include("Displaying.RideSchedule").FirstOrDefault();
            var seats = context.TicketSeats.Where(s => s.TicketId == ticket.IdTicket).ToList();
            var bus = context.AvialableSeats.Where(s => s.RideScheduleId == ticket.Displaying.RideSchedule.IdRideSchedule).Select(s => new { Bus = s.Bus }).Distinct().FirstOrDefault();*/

            var tickets = context.Tickets.Where(s => s.CustomerId == 14)
                .Include("Displaying.RideSchedule.RideDate.Ride.StartPoint")
                .Include("Displaying.RideSchedule.RideDate.Ride.DestinationPoint")
                .Include("Displaying.RideSchedule.Schedule")
                .Include("Customer")
                .ToList();

            List<TicketDisplay> result = new List<TicketDisplay>();
            
            foreach (Ticket ticket in tickets)
            {
                var seats = context.TicketSeats.Where(s => s.TicketId == ticket.IdTicket).Select(s => s.Seat).ToList();
                var bus = context.AvialableSeats.Where(s => s.RideScheduleId == ticket.Displaying.RideSchedule.IdRideSchedule).Select(s => s.Bus).Distinct().FirstOrDefault();

                result.Add(new TicketDisplay
                {
                    Ticket = ticket,
                    Bus = bus,
                    Seats = seats
                });
            }

            ticketsListView.ItemsSource = result;

            int g = 0;
        }
    }

    public class TicketDisplay
    {
        public Ticket Ticket { get; set; }
        public List<Seat> Seats { get; set; }
        private string _reservedSeats;
        public string ReservedSeats 
        { 
            get
            {
                foreach (Seat seat in Seats) _reservedSeats += $"R {seat.IdSeat} ";
                return _reservedSeats;
            }
        }
        public Bus Bus { get; set; }
    }
}
