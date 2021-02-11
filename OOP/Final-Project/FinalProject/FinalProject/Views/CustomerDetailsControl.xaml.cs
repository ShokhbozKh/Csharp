using System.Windows;
using System.Windows.Controls;

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
