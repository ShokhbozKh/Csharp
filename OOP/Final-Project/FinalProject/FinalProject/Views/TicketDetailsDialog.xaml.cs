using FinalProject.DAL;
using FinalProject.Models;
using System.Linq;
using System.Windows;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for TicketDetailsDialog.xaml
    /// </summary>
    public partial class TicketDetailsDialog : Window
    {
        public Ticket Ticket { get; set; }
        public Customer Customer { get; set; }
        public TicketDetailsDialog(Customer customer, Ticket ticket)
        {
            InitializeComponent();
            Ticket = ticket;
            Customer = customer;

            SetupUI();
        }

        void SetupUI()
        {
            ticketNumberLabel.Content = Ticket.TicketNumber;
            customerFullnameLabel.Content = Ticket.Customer.FullName;
            emailLabel.Content = Ticket.Customer.Email;
            phoneNumberLabel.Content = (Ticket.Customer as Customer).PassportId;
            startPointLabel.Content = $"{Ticket.Displaying.RideSchedule.RideDate.Ride.StartPoint.LocationName}, {Ticket.Displaying.RideSchedule.RideDate.Ride.StartPoint.StationName}";
            destinationPointLabel.Content = $"{Ticket.Displaying.RideSchedule.RideDate.Ride.DestinationPoint.LocationName}, {Ticket.Displaying.RideSchedule.RideDate.Ride.DestinationPoint.StationName}";
            departureTimeLabel.Content = $"{Ticket.Displaying.RideSchedule.RideDate.Date:ddd,MMM} {Ticket.Displaying.RideSchedule.Schedule.DepartureTime:HH:mm}";
            arrivalLabel.Content = $"{Ticket.Displaying.RideSchedule.RideDate.Date:ddd,MMM} {Ticket.Displaying.RideSchedule.Schedule.ArrivalTime:HH:mm}";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefundTicket_Click(object sender, RoutedEventArgs e)
        {
            var context = new DbService();

            // delete from Tickets table
            var ticketToDelete = context.Tickets.Where(s => s.IdTicket == Ticket.IdTicket).SingleOrDefault();
            context.Tickets.Remove(ticketToDelete);

            var ts = context.TicketSeats.ToList();
            var avs = context.AvialableSeats.Where(s => s.RideScheduleId == Ticket.Displaying.RideSchedule.IdRideSchedule).ToList();
            var displaying = context.Displayings.Where(s => s.IdDisplaying == Ticket.DisplayingId).SingleOrDefault();

            // remove from TicketSeats table
            Ticket.Seats.ToList().ForEach(seat =>
            {
                var seatToDelete = context.TicketSeats.Where(s => s.IdTicketSeats == seat.IdTicketSeats).SingleOrDefault();
                context.TicketSeats.Remove(seatToDelete);
            });

            // reset number of avialable seats for refunded displaying
            displaying.AvialableSeats += Ticket.Seats.Count;

            int g = 0;

            // reset state of avialable seats
            foreach(var seat in avs)
            {
                foreach(var ticketSeat in Ticket.Seats)
                {
                    if (ticketSeat.SeatId == seat.SeatId) seat.IsAvialable = true;
                }
            }

            context.SaveChanges();

            Close();
        }
    }
}
