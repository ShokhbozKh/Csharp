using BudgetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.DAL
{
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category", schema: "Budget");
            modelBuilder.Entity<Income>().ToTable("Income", schema: "Budget");
            modelBuilder.Entity<Expense>().ToTable("Expense", schema: "Budget");
            modelBuilder.Entity<History>().ToTable("History", schema: "Budget");

            base.OnModelCreating(modelBuilder);
        }
    }
}
