using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl, INotifyPropertyChanged
    {
        public SearchControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {
                throw new Exception("Cannot initialize search control");
            }

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
        
        private int m_progress;
        public int Progress
        {
            get { return m_progress; }
            set
            {
                if(value <= 5 || value > 0)
                {
                    m_progress = value;
                    OnPropertyChanged("Progress");
                }
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
            Progress += 1;
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            Progress -= 1;
        }
    }
}
