namespace HistogramUi.ViewModels
{
    using Histogram.Core.Services;
    using LiveCharts;
    using LiveCharts.Wpf;
    using Microsoft.AppCenter.Crashes;
    using Prism.Commands;
    using Prism.Mvvm;
    using System;
    using System.Linq;
    using System.Windows;

    public class MainWindowViewModel : BindableBase
    {
        private IHistogramService _histogramService;

        private string _title = Resources.Lang.AppTitle;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private DateTime _startDate = DateTime.Now.AddMonths(-1);
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private int _numberOfBins = 4;
        public int NumberOfBins
        {
            get => _numberOfBins;
            set => SetProperty(ref _numberOfBins, value);
        }

        private SeriesCollection _chartDataCollection = new SeriesCollection();
        public SeriesCollection ChartDataCollection
        {
            get => _chartDataCollection;
            set => SetProperty(ref _chartDataCollection, value);
        }

        private string [] _chartLabels;
        public string [] ChartLabels
        {
            get => _chartLabels;
            set => SetProperty(ref _chartLabels, value);
        }

        public Func<int, string> Formatter { get; set; }

        public DelegateCommand CalculateHistogramCommand { get; private set; }

        public MainWindowViewModel(IHistogramService histogramService)
        {
            Init(histogramService);
        }

        private void Init(IHistogramService histogramService)
        {
            _histogramService = histogramService;
            CalculateHistogramCommand = new DelegateCommand(OnCalculateHistogram);
        }

        private void OnCalculateHistogram()
        {
            try
            {
                var chartDataResults = _histogramService.ProvideChartData(_startDate, _endDate, _numberOfBins);
                ChartDataCollection.Clear();
                ChartDataCollection.Add(new ColumnSeries
                {
                    Values = new ChartValues<int>(chartDataResults.Select(chartData => chartData.Data))
                });

                ChartLabels = chartDataResults.Select(chartData => chartData.Label).ToArray();
                Formatter = value => value.ToString("N");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, Resources.Lang.ArgumentExceptionError);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                throw ex;
            }
        }
    }
}