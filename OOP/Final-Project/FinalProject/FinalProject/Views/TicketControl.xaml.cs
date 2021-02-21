using FinalProject.DAL;
using FinalProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for TicketControl.xaml
    /// </summary>
    public partial class TicketControl : UserControl
    {
        public Ticket Ticket { get; set; }
        public TicketControl(Ticket ticket)
        {
            InitializeComponent();
            seats.Content = "";
            Ticket = ticket;
            SetUpUI();
        }

        void SetUpUI()
        {
            var context = new DbService();

            var ticket = context.Tickets
                .Where(s => s.IdTicket == Ticket.IdTicket)
                .Include("Displaying.RideSchedule.RideDate.Ride.StartPoint")
                .Include("Displaying.RideSchedule.RideDate.Ride.DestinationPoint")
                .Include("Displaying.RideSchedule.Schedule")
                .Include("Customer")
                .FirstOrDefault();

            Ticket = ticket;
            
            var ticketSeats = context.TicketSeats.Where(s => s.TicketId == Ticket.IdTicket).ToList();

            var bus = context.AvialableSeats
                .Where(s => s.RideScheduleId == Ticket.Displaying.RideSchedule.IdRideSchedule)
                .Select(s => s.Bus).FirstOrDefault();

            int g = 0;

            var stops = context.RideStops
                .Where(s => s.RideId == Ticket.Displaying.RideSchedule.RideDate.Ride.IdRide)
                .Include("Location")
                .ToList();

            fromLabel.Content = Ticket.Displaying.RideSchedule.RideDate.Ride.StartPoint.LocationName;
            toLabel.Content = Ticket.Displaying.RideSchedule.RideDate.Ride.DestinationPoint.LocationName;

            rideDateLabel.Content = Ticket.Displaying.RideSchedule.RideDate.Date.ToString("MMMM dd, yyyy");

            ticketTypeLabel.Content = Ticket.TicketType.ToString();

            passengerName.Content = Ticket.Customer.FirstName + Ticket.Customer.LastName;
            ticketNumber.Content = Ticket.TicketNumber;
            foreach(var seat in ticketSeats)
            {
                seats.Content += $"R{seat.SeatId}";
            }

            busType.Content = bus.BusType;
            departureTime.Content = Ticket.Displaying.RideSchedule.Schedule.DepartureTime.ToString("mm:HH");
            arrivalTime.Content = Ticket.Displaying.RideSchedule.Schedule.ArrivalTime.ToString("mm:HH");
            starPoint.Content = Ticket.Displaying.RideSchedule.RideDate.Ride.StartPoint.StationName;
            destinationPoint.Content = Ticket.Displaying.RideSchedule.RideDate.Ride.DestinationPoint.StationName;
            
            for(int i = 0; i < stops.Count; i++)
            {
                if (i == 0) stop1.Content = stops[i].Location.StationName;
                if (i == 1) stop2.Content = stops[i].Location.StationName;
                if (i == 2) stop3.Content = stops[i].Location.StationName;
            }
        }
    }
}
