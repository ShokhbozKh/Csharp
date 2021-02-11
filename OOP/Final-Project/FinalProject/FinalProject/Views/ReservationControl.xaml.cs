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
        public ReservationControl()
        {
            InitializeComponent();

            _middleFrame.Navigate(new SearchControl());
            
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

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_progress + 1 <= 5)
            {
                Progress += 1;

                switch (Progress)
                {
                    case 1:
                        _middleFrame.Navigate(new RideDetailsControl());
                        break;
                    case 2:
                        _middleFrame.Navigate(new SeatingArea());
                        break;
                    case 3:
                        _middleFrame.Navigate(new CustomerDetailsControl());
                        break;
                    case 4:
                        _middleFrame.Navigate(new PaymetControl());
                        break;
                    case 5:
                        _middleFrame.Navigate(new TicketControl());
                        break;
                }
            }
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_progress - 1 >= 0)
            {
                Progress -= 1;
                _middleFrame.GoBack();
            }
        }

    }
}
