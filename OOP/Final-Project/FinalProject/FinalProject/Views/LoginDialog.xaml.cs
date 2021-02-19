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

            var rideSchedules = context.RideSchedules.ToList();

            foreach(var rs in rideSchedules)
            {
                context.Displayings.Add(new Displaying
                {
                    IdDisplaying = rs.IdRideSchedule,
                    StandardPrice = new Random().Next(20, 150),
                    AvialableSeats = 20,
                    IsDeparted = false
                });
            }

            int g = 0;

            context.SaveChanges();
        }
    }
}
