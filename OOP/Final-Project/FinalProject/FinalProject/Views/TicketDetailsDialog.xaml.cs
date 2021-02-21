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
        public TicketDetailsDialog(Ticket ticket)
        {
            InitializeComponent();
            Ticket = ticket;

            int g = 0;

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

            // reset avialability of seats
            Ticket.Seats.ToList().ForEach(seat =>
            {
                Ticket.Displaying.RideSchedule.AvialableSeats.ToList().ForEach(avs =>
                {
                    if (avs.SeatId == seat.SeatId)
                    {
                        context.AvialableSeats.Attach(avs);
                        avs.IsAvialable = true;
                    }
                });
            });

            // remove from db
            Ticket.Seats.ToList().ForEach(el =>
            {
                Ticket.Seats.Remove(el);
            });

            // reset number of avialable seats for refunded displaying
            context.Displayings.Attach(Ticket.Displaying);
            Ticket.Displaying.AvialableSeats += Ticket.Seats.Count;

            int g = 0;

            context.SaveChanges();

            Close();
        }
    }
}
