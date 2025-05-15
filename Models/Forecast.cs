using System;

namespace ForecastBudgetApp.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal Profit { get; set; }
        public string Comments { get; set; }
    }
}
