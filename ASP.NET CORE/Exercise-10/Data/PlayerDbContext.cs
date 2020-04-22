using Exercise_10.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_10.Data
{
    public class PlayerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16333;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Player>()
                .HasKey(p => new
                {
                    p.IdPlayer,
                    p.IdTeam
                });*/ // Composite key

            /*modelBuilder.Entity<Player>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(15);
                
            modelBuilder.Entity<Player>()
                .HasKey(p => p.IdPlayer);*/

            base.OnModelCreating(modelBuilder);
        }

        public PlayerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
