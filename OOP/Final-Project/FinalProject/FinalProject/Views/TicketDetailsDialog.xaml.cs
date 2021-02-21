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
        public TicketDisplay Ticket { get; set; }
        public TicketDetailsDialog(TicketDisplay ticket)
        {
            InitializeComponent();
            Ticket = ticket;

            SetupUI();
        }

        void SetupUI()
        {
            ticketNumberLabel.Content = Ticket.Ticket.TicketNumber;
            customerFullnameLabel.Content = Ticket.Ticket.Customer.FullName;
            emailLabel.Content = Ticket.Ticket.Customer.Email;
            phoneNumberLabel.Content = (Ticket.Ticket.Customer as Customer).PassportId;
            startPointLabel.Content = $"{Ticket.Ticket.Displaying.RideSchedule.RideDate.Ride.StartPoint.LocationName}, {Ticket.Ticket.Displaying.RideSchedule.RideDate.Ride.StartPoint.StationName}";
            destinationPointLabel.Content = $"{Ticket.Ticket.Displaying.RideSchedule.RideDate.Ride.DestinationPoint.LocationName}, {Ticket.Ticket.Displaying.RideSchedule.RideDate.Ride.DestinationPoint.StationName}";
            departureTimeLabel.Content = $"{Ticket.Ticket.Displaying.RideSchedule.RideDate.Date:ddd,MMM} {Ticket.Ticket.Displaying.RideSchedule.Schedule.DepartureTime:HH:mm}";
            arrivalLabel.Content = $"{Ticket.Ticket.Displaying.RideSchedule.RideDate.Date:ddd,MMM} {Ticket.Ticket.Displaying.RideSchedule.Schedule.ArrivalTime:HH:mm}";
            seatsLabel.Content = Ticket.ReservedSeats;
            busTypeLabel.Content = Ticket.Bus.BusType;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefundTicket_Click(object sender, RoutedEventArgs e)
        {
            var context = new DbService();

            var ts = context.TicketSeats.ToList();
            var ticketToDelete = context.Tickets.Where(s => s.IdTicket == Ticket.Ticket.IdTicket).SingleOrDefault();
            var avs = context.AvialableSeats.Where(s => s.RideScheduleId == Ticket.Ticket.Displaying.RideSchedule.IdRideSchedule).ToList();
            var displaying = context.Displayings.Where(s => s.IdDisplaying == Ticket.Ticket.DisplayingId).SingleOrDefault();

            ts.ForEach(s =>
            {
                if (s.TicketId == Ticket.Ticket.IdTicket)
                {
                    context.TicketSeats.Attach(s);
                    context.TicketSeats.Remove(s);
                }
            });

            if(ticketToDelete != null)
            {
                context.Tickets.Remove(ticketToDelete);
            }

            displaying.AvialableSeats += Ticket.Seats.Count;

            avs.ForEach(s =>
            {
                if (Ticket.Seats.Contains(s.Seat))
                {
                    s.IsAvialable = true;
                }
            });

            int g = 0;

            context.SaveChanges();
        }
    }
}
