using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ForecastBudgetApp.Models;
using ForecastBudgetApp.Services;
using ForecastBudgetApp.ViewModels;

namespace ForecastBudgetApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        private readonly DataService _dataService;
        private readonly ExportService _exportService;
        private readonly ComparisonService _comparisonService;
        private readonly ApprovalService _approvalService;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            _dataService = new DataService();
            _exportService = new ExportService();
            _comparisonService = new ComparisonService();
            _approvalService = new ApprovalService();

            DataContext = _viewModel;
            LoadData();
        }

        private void LoadData()
        {
            var forecastData = _dataService.GetForecastData();
            var budgetData = _dataService.GetBudgetData();
            _viewModel.ForecastData = forecastData;
            _viewModel.BudgetData = budgetData;
        }

        private void CreateNewVersionButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for creating a new version
        }

        private void ExportToXLSXButton_Click(object sender, RoutedEventArgs e)
        {
            var data = _viewModel.ForecastData.Concat(_viewModel.BudgetData).ToList();
            _exportService.ExportToXLSX(data);
        }

        private void ComparePlansButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for comparing plans
        }
    }
}
