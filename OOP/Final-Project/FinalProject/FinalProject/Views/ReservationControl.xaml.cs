using FinalProject.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for ReservationControl.xaml
    /// </summary>
    public partial class ReservationControl : UserControl, INotifyPropertyChanged
    {
        private Customer CustomerDetails { get; set; }
        private List<int> SelectedSeats { get; set; }
        private Displaying _selectedDisplaying;
        public Displaying SelectedDisplaying 
        {
            get => _selectedDisplaying;
            set
            {
                if (_selectedDisplaying != value)
                {
                    nextButton.IsEnabled = true;
                    _selectedDisplaying = value;
                    OnPropertyChanged("Displaying");
                }
            }
        }

        private int m_progress = 1;
        public int Progress
        {
            get { return m_progress; }
            set
            {
                m_progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public ObservableCollection<string> Steps
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ReservationControl()
        {
            InitializeComponent();

            _middleFrame.Navigate(new SearchControl(ref nextButton));

            _middleFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            Steps = new ObservableCollection<string>
            {
                "Select route & Date",
                "Book Seat",
                "Passenger details",
                "Payment",
                "Print Ticket"
            };
            this.DataContext = this;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_progress + 1 <= 5)
            {
                Progress += 1;

                if (Progress == 4) nextButton.Content = "Buy";
                else nextButton.Content = "Next";

                switch (Progress)
                {
                    case 1:
                        _middleFrame.Navigate(new RideDetailsControl());
                        break;
                    case 2:
                        SelectedDisplaying = SearchControl.SelectedRide;
                        if(SelectedDisplaying == null)
                        {
                            MessageBox.Show("Please choose a ride");
                            Progress -= 1;
                            break;
                        }
                        else
                        {
                            backButton.IsEnabled = true;
                            _middleFrame.Navigate(new SeatingArea(SelectedDisplaying.RideSchedule.IdRideSchedule));
                        }
                        break;
                    case 3:
                        SelectedSeats = SeatingArea.SelectedSeats;

                        if(SelectedSeats.Count > 0)
                        {
                            _middleFrame.Navigate(new CustomerDetailsControl(ref nextButton));
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Please, choose seat(s)");
                            break;  
                        }
                        
                    case 4:
                        CustomerDetails = CustomerDetailsControl.Customer;

                        _middleFrame.Navigate(new PaymetControl());
                        break;
                    case 5:
                        int g = 0;
                        Ticket.ReserveTicket(CustomerDetails, SelectedDisplaying, SelectedSeats);
                        _middleFrame.Navigate(new TicketControl());
                        break;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_progress - 1 >= 1)
            {
                Progress -= 1;
                _middleFrame.GoBack();

                if (Progress == 1) backButton.IsEnabled = false;
            }
        }

        public void DisplayingSelected(object sender, SelectionChangedEventArgs e)
        {
            SelectedDisplaying = ((sender as ListView).SelectedItem as DisplayingsBus)?.Displaying;
        }
    }
}
