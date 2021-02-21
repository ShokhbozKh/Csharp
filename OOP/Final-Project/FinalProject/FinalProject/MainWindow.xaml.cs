using System;
using System.Collections.Generic;
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
using FinalProject.Views;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //new LoginDialog().Show();
            _middleFrame.Navigate(new ReservationControl());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelTicket_Click(object sender, RoutedEventArgs e)
        {
            _middleFrame.Navigate(new CancelTicketControl());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTrip_Click(object sender, RoutedEventArgs e)
        {
            _middleFrame.Navigate(new ReservationControl());
        }
    }
}
