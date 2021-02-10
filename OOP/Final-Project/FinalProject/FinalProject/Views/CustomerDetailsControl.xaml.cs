using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for CustomerDetailsControl.xaml
    /// </summary>
    public partial class CustomerDetailsControl : UserControl
    {
        private bool IsLoading { get; set; } = false;
        public CustomerDetailsControl()
        {
            InitializeComponent();
        }

        private void RegisterCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoading)
            {
                this.spinner.Visibility = Visibility.Visible;
                IsLoading = !IsLoading;
            }
            else
            {
                this.spinner.Visibility = Visibility.Collapsed;
                IsLoading = !IsLoading;
            }
        }

        /*private void rbtnSymbol_Checked(object sender, RoutedEventArgs e)
        {
            expS.IsExpanded = true;
            expP.IsExpanded = false;
        }

        private void rbtnPicture_Checked(object sender, RoutedEventArgs e)
        {
            expS.IsExpanded = false;
            expP.IsExpanded = true;
        }*/
    }
}
