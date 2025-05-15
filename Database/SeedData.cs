using System;
using System.Linq;
using ForecastBudgetApp.Models;

namespace ForecastBudgetApp.Database
{
    public static class SeedData
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Forecasts.Any())
            {
                context.Forecasts.AddRange(
                    new Forecast
                    {
                        Date = new DateTime(2023, 1, 1),
                        Revenue = 100000,
                        Expenses = 50000,
                        Profit = 50000,
                        Comments = "Initial forecast for Q1 2023"
                    },
                    new Forecast
                    {
                        Date = new DateTime(2023, 4, 1),
                        Revenue = 120000,
                        Expenses = 60000,
                        Profit = 60000,
                        Comments = "Initial forecast for Q2 2023"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Budgets.Any())
            {
                context.Budgets.AddRange(
                    new Budget
                    {
                        Date = new DateTime(2023, 1, 1),
                        Revenue = 100000,
                        Expenses = 50000,
                        Profit = 50000,
                        Comments = "Initial budget for 2023",
                        IsApproved = false,
                        ApprovedBy = null
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
