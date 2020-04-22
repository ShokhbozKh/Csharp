using Exercise_08.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_08.Models
{
    public class AnimalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16333;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<AnimalClinic> AnimalClinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FluentAPI
            modelBuilder.Entity<AnimalClinic>().HasKey(p => p.IdAnimalClinic);
            modelBuilder.Entity<AnimalClinic>().Property(p => p.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<AnimalClinic>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<AnimalClinic>().HasOne(p => p.Owner).WithMany(p => p.AnimalClinics).HasForeignKey(p => p.IdOwner);

            base.OnModelCreating(modelBuilder);
        }
    }
}
