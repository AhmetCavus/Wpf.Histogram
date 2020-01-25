
namespace Histogram.Core.Services
{
    using DataGenerator;
    using Histogram.Core.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HistogramService : IHistogramService
    {
        private const int LowerBound = -1000;
        private const int UpperBound = 1000;

        private IBinProvider _binProvider;
        private IReadOnlyCollection<HistogramEntry> _histogramEntries;

        private DateTime? _startDate;
        public DateTime? StartDate => _startDate ?? (_startDate = _histogramEntries.Min(entry => entry.OccurrenceDate));

        private DateTime? _endDate;
        public DateTime? EndDate => _endDate ?? (_endDate = _histogramEntries.Max(entry => entry.OccurrenceDate));

        public HistogramService(IBinProvider binProvider)
        {
            Init(binProvider);
        }

        public IReadOnlyCollection<IChartData<int>> ProvideChartData(DateTime startDate, DateTime endDate, int countOfBins)
        {
            if (startDate >= endDate) throw new ArgumentException();
            if (startDate < _startDate || endDate > _endDate) throw new ArgumentException();
            var bins = _binProvider.CreateBins(LowerBound, UpperBound, countOfBins);
            List<IChartData<int>> chartDataList = CreateEmptyChartDataList();
            var filteredHistogramEntries = FilterHistogramEntries(startDate, endDate);
            FillChartDataList(bins, filteredHistogramEntries, chartDataList);
            return chartDataList;
        }

        private void Init(IBinProvider binProvider)
        {
            _binProvider = binProvider;
            _histogramEntries = HistogramDataGenerator.GetRandomHistogramData();
        }

        private List<IChartData<int>> CreateEmptyChartDataList() =>
            new List<IChartData<int>>();

        private IEnumerable<HistogramEntry> FilterHistogramEntries(DateTime startDate, DateTime endDate) =>
            _histogramEntries.Where(entry => startDate <= entry.OccurrenceDate && entry.OccurrenceDate <= endDate);

        private void FillChartDataList(IReadOnlyCollection<IBinData> bins, IEnumerable<HistogramEntry> filteredHistogramEntries, List<IChartData<int>> chartDataList)
        {
            foreach (var bin in bins)
            {
                bin.Count = filteredHistogramEntries.Count(entry => bin.Range.Start <= entry.NumberValue && entry.NumberValue <= bin.Range.End);
                chartDataList.Add(new ChartData<int>(label: $"[{bin.Range.Start} - {bin.Range.End}]", data: bin.Count));
            }
        }
    }
}