using Microsoft.EntityFrameworkCore;
using ForecastBudgetApp.Models;

namespace ForecastBudgetApp.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forecast>().ToTable("Forecasts");
            modelBuilder.Entity<Budget>().ToTable("Budgets");
        }
    }
}
