using FinalProject.DAL;
using FinalProject.Models;
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
using System.Windows.Shapes;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        public LoginDialog()
        {
            InitializeComponent();

            LoadData();
        }

        void LoadData()
        {
            var context = new DbService();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var drivers = context.Drivers.ToList();
            var customers = context.Customers.ToList();
            var users = context.Users.ToList();

            int g = 0;
        }
    }
}
