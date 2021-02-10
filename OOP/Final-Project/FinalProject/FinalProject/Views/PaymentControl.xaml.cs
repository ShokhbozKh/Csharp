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

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for PaymetControl.xaml
    /// </summary>
    public partial class PaymetControl : UserControl
    {
        public bool Bitcoin { get; set; } = false;
        public PaymetControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.bitcoinTextbox.Visibility = Visibility.Visible;
            this.bitcoinTextbox.Margin = new Thickness(0, 5, 0, 30);
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            this.bitcoinTextbox.Visibility = Visibility.Hidden;
            this.bitcoinTextbox.Margin = new Thickness(0);
        }
    }
}
