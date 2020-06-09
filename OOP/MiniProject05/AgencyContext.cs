using Microsoft.EntityFrameworkCore;
using MiniProject05.Models;
using System;

namespace MiniProject05
{
    class AgencyContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarForRent> CarsForRent { get; set; }
        public DbSet<CarForSale> CarsForSale { get; set; }
        
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<RentAgreement> RentAgreements { get; set; }
        public DbSet<SaleAgreement> SaleAgreements { get; set; }

        public DbSet<ClassAttributes> ClassAttributes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16333;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client", schema: "RentAgency");
            modelBuilder.Entity<Agent>().ToTable("Agent", schema: "RentAgency");
            modelBuilder.Entity<Car>().ToTable("Car", schema: "RentAgency")
                .Property(e => e.Photos)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<CarForSale>().ToTable("Car_For_Sale", schema: "RentAgency");
            modelBuilder.Entity<CarForRent>().ToTable("Car_For_Rent", schema: "RentAgency");
            modelBuilder.Entity<Agreement>().ToTable("Agreement", schema: "RentAgency");
            modelBuilder.Entity<RentAgreement>().ToTable("Rent_Agreement", schema: "RentAgency");
            modelBuilder.Entity<SaleAgreement>().ToTable("Sale_Agreement", schema: "RentAgency");
            modelBuilder.Entity<ClassAttributes>().ToTable("Class_Attribute", schema: "RentAgency");

        }

        /*public virtual void Configure(EntityTypeBuilder<CarForRent> builder)
        {
            if (typeof(CarForRent).BaseType == null)
                builder.ToTable(typeof(CarForRent).Name, "RentAgency");
        }*/
    }
}
