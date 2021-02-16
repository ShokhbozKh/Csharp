using System;
using FinalProject.DAL;
using FinalProject.Models;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

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
            /* var users = context.Users.ToList();
             List<Customer> customers = context.Customers.ToList();
             List<Employee> employees = context.Employees.ToList();
             var emp = employees[0];
             *//*context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
             var drivers = context.Drivers.ToList();
             var customers = context.Customers.ToList();
             var users = context.Users.ToList();*//*

             Customer customer = new Customer()
             {
                 FirstName = "John",
                 LastName = "Done",
                 BirthDate = DateTime.Now,
                 CustomerType = CustomerType.Loyal,
                 Discount = null,
                 Email = "john@gmail.com",
                 Login = "Login1",
                 Password = "Password1",
                 PhoneNumber = "250 521 322"
             };

             Employee employee = new Employee()
             {
                 FirstName = "Alex",
                 LastName = "Gustafson",
                 Login = "Alex",
                 Password = "Password12",
                 HireDate = DateTime.Now,
                 Discount = 5,
                 Email = "alex@mail.com",
             };

             context.Customers.Add(customer);
             context.SaveChanges();
             context.Employees.Add(employee);
             context.SaveChanges();

             Console.WriteLine(customers[0]);*/

            var rideDates = context.RideDates.ToList();
            var schedules = context.Schedules.ToList();

            foreach(RideDate rideDate in rideDates)
            {
                foreach(Schedule schedule in schedules)
                {
                    context.RideSchedules.Add(new RideSchedule { ScheduleId = schedule.IdRideSchedule, RideDateId = rideDate.IdRideData });
                }
            }

            context.SaveChanges();

            int g = 0;
        }
    }
}
