using FinalProject.DAL;
using FinalProject.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Customer> Customers { get; set; }
        private DbService context { get; set; }
        public CancelTicketControl()
        {
            InitializeComponent();

            context = new DbService();
            Customers = new ObservableCollection<Customer>();
            LoadData();
        }

        void LoadData()
        {
            var tickets = context.Tickets
                .Include("Displaying.RideSchedule.RideDate.Ride.StartPoint")
                .Include("Displaying.RideSchedule.RideDate.Ride.DestinationPoint")
                .Include("Displaying.RideSchedule.Schedule")
                .ToList();

            context.Customers.Include("Tickets.Seats.Seat").ToList().ForEach(el => Customers.Add(el));

            customersListBox.ItemsSource = Customers;

            int g = 0;
        }

        private void TicketsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedTicket = ticketsListView.SelectedItem as Ticket;
            var selectedCustomer = customersListBox.SelectedItem as Customer;

            var s = selectedTicket.Seats;

            int g = 0;

            if(selectedTicket != null)
            {
                var dialog = new TicketDetailsDialog(selectedCustomer, selectedTicket);
                dialog.Show();
            }
        }

        private void SearchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var context = new DbService();

            var customer = context.Customers.Where(s => s.UserId == 14).Include("Tickets").SingleOrDefault();

            int g = 0;

            List<TicketDisplay> result = new List<TicketDisplay>();
            
            foreach (Ticket ticket in customer.Tickets)
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
        }

        private void CustomersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var customer = customersListBox.SelectedItem as Customer;
            ticketsListView.ItemsSource = customer.Tickets.ToList();

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
