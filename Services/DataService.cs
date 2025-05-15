using System.Collections.Generic;
using System.Linq;
using ForecastBudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForecastBudgetApp.Services
{
    public class DataService
    {
        private readonly DatabaseContext _context;

        public DataService()
        {
            _context = new DatabaseContext();
        }

        public List<Forecast> GetForecastData()
        {
            return _context.Forecasts.ToList();
        }

        public List<Budget> GetBudgetData()
        {
            return _context.Budgets.ToList();
        }

        public void SaveForecastData(Forecast forecast)
        {
            if (forecast.Id == 0)
            {
                _context.Forecasts.Add(forecast);
            }
            else
            {
                _context.Forecasts.Update(forecast);
            }
            _context.SaveChanges();
        }

        public void SaveBudgetData(Budget budget)
        {
            if (budget.Id == 0)
            {
                _context.Budgets.Add(budget);
            }
            else
            {
                _context.Budgets.Update(budget);
            }
            _context.SaveChanges();
        }
    }
}
