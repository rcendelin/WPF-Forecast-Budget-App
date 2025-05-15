using System.Collections.ObjectModel;
using ForecastBudgetApp.Models;
using ForecastBudgetApp.Services;

namespace ForecastBudgetApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly DataService _dataService;
        private readonly ExportService _exportService;
        private readonly ComparisonService _comparisonService;
        private readonly ApprovalService _approvalService;

        public MainViewModel()
        {
            _dataService = new DataService();
            _exportService = new ExportService();
            _comparisonService = new ComparisonService();
            _approvalService = new ApprovalService();

            LoadData();
        }

        private ObservableCollection<Forecast> _forecastData;
        public ObservableCollection<Forecast> ForecastData
        {
            get { return _forecastData; }
            set
            {
                _forecastData = value;
                OnPropertyChanged(nameof(ForecastData));
            }
        }

        private ObservableCollection<Budget> _budgetData;
        public ObservableCollection<Budget> BudgetData
        {
            get { return _budgetData; }
            set
            {
                _budgetData = value;
                OnPropertyChanged(nameof(BudgetData));
            }
        }

        private void LoadData()
        {
            var forecastData = _dataService.GetForecastData();
            var budgetData = _dataService.GetBudgetData();
            ForecastData = new ObservableCollection<Forecast>(forecastData);
            BudgetData = new ObservableCollection<Budget>(budgetData);
        }

        public void CreateNewVersion()
        {
            // Implement logic for creating a new version
        }

        public void ExportToXLSX()
        {
            var data = ForecastData.Concat(BudgetData).ToList();
            _exportService.ExportToXLSX(data);
        }

        public void ComparePlans()
        {
            // Implement logic for comparing plans
        }
    }
}
