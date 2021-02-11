using System;
using System.Data.Entity;
using FinalProject.Models;
using System.Linq;

namespace FinalProject.DAL
{
    public class DbService : DbContext
    {
        // Your context has been configured to use a 'DbService' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FinalProject.DAL.DbService' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbService' 
        // connection string in the application configuration file.
        public DbService()
            : base("name=DbService")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }        
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<DiscountReason> DiscountReasons { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<RideStop> RideStops { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}