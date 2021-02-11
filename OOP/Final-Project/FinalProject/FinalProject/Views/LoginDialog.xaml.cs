using FinalProject.DAL;
using System.Linq;
using System.Windows;

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
