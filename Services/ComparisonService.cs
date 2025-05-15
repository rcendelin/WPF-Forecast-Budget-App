using System.Collections.Generic;
using System.Linq;
using ForecastBudgetApp.Models;

namespace ForecastBudgetApp.Services
{
    public class ComparisonService
    {
        public List<ComparisonResult> CompareForecasts(List<Forecast> forecasts1, List<Forecast> forecasts2)
        {
            var comparisonResults = new List<ComparisonResult>();

            foreach (var forecast1 in forecasts1)
            {
                var forecast2 = forecasts2.FirstOrDefault(f => f.Date == forecast1.Date);
                if (forecast2 != null)
                {
                    var result = new ComparisonResult
                    {
                        Date = forecast1.Date,
                        RevenueDifference = forecast1.Revenue - forecast2.Revenue,
                        ExpensesDifference = forecast1.Expenses - forecast2.Expenses,
                        ProfitDifference = forecast1.Profit - forecast2.Profit
                    };
                    comparisonResults.Add(result);
                }
            }

            return comparisonResults;
        }

        public List<ComparisonResult> CompareBudgets(List<Budget> budgets1, List<Budget> budgets2)
        {
            var comparisonResults = new List<ComparisonResult>();

            foreach (var budget1 in budgets1)
            {
                var budget2 = budgets2.FirstOrDefault(b => b.Date == budget1.Date);
                if (budget2 != null)
                {
                    var result = new ComparisonResult
                    {
                        Date = budget1.Date,
                        RevenueDifference = budget1.Revenue - budget2.Revenue,
                        ExpensesDifference = budget1.Expenses - budget2.Expenses,
                        ProfitDifference = budget1.Profit - budget2.Profit
                    };
                    comparisonResults.Add(result);
                }
            }

            return comparisonResults;
        }
    }

    public class ComparisonResult
    {
        public DateTime Date { get; set; }
        public decimal RevenueDifference { get; set; }
        public decimal ExpensesDifference { get; set; }
        public decimal ProfitDifference { get; set; }
    }
}
