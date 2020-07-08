using MAS_Final.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MAS_Final.DAL
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCustomerTypeDict> CustomerCustomerTypeDicts { get; set; }
        public virtual DbSet<CustomertypeDict> CustomertypeDicts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Stewardress> Stewardresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>().ToTable("Bus", schema: "Travel");
            modelBuilder.Entity<User>().ToTable("User", schema: "Travel");
            modelBuilder.Entity<Customer>().ToTable("Customer", schema: "Travel");
            modelBuilder.Entity<CustomerCustomerTypeDict>().ToTable("CustomerCustomerTypeDict", schema: "Travel");
            modelBuilder.Entity<CustomertypeDict>().ToTable("CustomerTypeDict", schema: "Travel");
            modelBuilder.Entity<Employee>().ToTable("Employee", schema: "Travel");
            modelBuilder.Entity<Driver>().ToTable("Driver", schema: "Travel");
            modelBuilder.Entity<Stewardress>().ToTable("Stewardress", schema: "Travel");


            base.OnModelCreating(modelBuilder);
        }
    }
}
