using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for RegisterCustomerDialog.xaml
    /// </summary>
    public partial class RegisterCustomerDialog : Window
    {
        public Customer Customer { get; set; }
        private List<CustomerType> CustomerTypes { get; set; } = new List<CustomerType>();
        private readonly DbService context;

        public RegisterCustomerDialog()
        {
            InitializeComponent();
            LoadData();
            context = new DbService();
        }

        private void LoadData()
        {
            CustomerTypes.Add(CustomerType.Loyal);
            CustomerTypes.Add(CustomerType.Student);

            customerTypeCombobox.ItemsSource = CustomerTypes;
        }

        private void RegisterCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer = new Customer
            {
                FirstName = fullNameTextBox.Text.Split(' ')[0],
                LastName = fullNameTextBox.Text.Split(' ')[1],
                Login = loginTextBox.Text,
                Password = passwordTextBox.Text,
                PassportId = passportTextBox.Text,
                BirthDate = birthdate.SelectedDate.GetValueOrDefault(),
                Email = emailTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text,
                CustomerType = (CustomerType)Enum.Parse(typeof(CustomerType), customerTypeCombobox.SelectedItem.ToString())
            };

            context.Users.Add(Customer);

            context.SaveChanges();

            //int g = 0;

            Close();
        }
    }
}