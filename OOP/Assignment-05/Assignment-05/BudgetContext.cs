using Assignment_05.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_05
{
    public class BudgetContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=BudgetManagement.db");
    }
}
