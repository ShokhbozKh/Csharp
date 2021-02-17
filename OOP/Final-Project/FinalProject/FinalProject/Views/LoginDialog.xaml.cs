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
            /*var rs = context.RideSchedules.Include("Schedule").ToList();
            var avs = context.AvialableSets.Include("Bus.Driver").Select(s => new
            {
                rideSchedule = s.RideSchedule,
                bus = s.Bus
            }).Distinct().ToList();

            foreach (var av in avs)
            {
                context.Displayings.Add(new Displaying
                {
                    RideScheduleId = av.rideSchedule.IdRideSchedule,
                    BusId = av.bus.IdBus,
                    DepartureTime = av.rideSchedule.Schedule.DepartureTime,
                    ArrivalTime = av.rideSchedule.Schedule.ArrivalTime,
                    AvialableSeats = 20,
                    IsDeparted = false,
                    StandardPrice = new Random().Next(20, 50)
                });
            }*/

             int  g = 0;

            context.SaveChanges();
        }
    }
}
