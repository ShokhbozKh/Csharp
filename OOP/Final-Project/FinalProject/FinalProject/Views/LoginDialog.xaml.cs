using System;
using FinalProject.DAL;
using FinalProject.Models;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;

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

            var displayings = context.Displayings.Include("RideSchedule").ToList();

            int g = 0;

            context.SaveChanges();
        }
    }
}
