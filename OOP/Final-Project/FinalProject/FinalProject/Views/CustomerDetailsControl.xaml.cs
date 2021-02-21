using FinalProject.DAL;
using FinalProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for CustomerDetailsControl.xaml
    /// </summary>
    public partial class CustomerDetailsControl : UserControl
    {
        private DbService Context { get; set; }
        private readonly Button nextButton;
        private List<Customer> UsersList { get; set; } = new List<Customer>();
        public static Customer Customer { get; set; }

        public CustomerDetailsControl(ref Button nextButton)
        {
            nextButton.IsEnabled = false;
            Context = new DbService();
            this.nextButton = nextButton;

            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            UsersList = Context.Customers.ToList();
        }

        private void RegisterCustomer_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new RegisterCustomerDialog();

            if(dialog.ShowDialog() == true)
            {
                Customer = dialog.Customer;
                UsersList.Add(Customer);
            }
        }

        private void PassportIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Customer = UsersList.Where(s => s.PassportId == passportIdTextBox.Text).FirstOrDefault();            

            if (Customer != null) nextButton.IsEnabled = true;
            else nextButton.IsEnabled = false;
        }
    }
}
