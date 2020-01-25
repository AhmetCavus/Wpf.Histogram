namespace Histogram.Core.Services
{
    using Histogram.Core.Data;
    using System;
    using System.Collections.Generic;
    public interface IHistogramService
    {
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
        IReadOnlyCollection<IChartData<int>> ProvideChartData(DateTime startTime, DateTime endTime, int countOfBins);
    }
}