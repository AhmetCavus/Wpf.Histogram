namespace Histogram.Core.Services
{
    using Histogram.Core.Data;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A service for providing the necessary information for displaying a histogram.
    /// </summary>
    public interface IHistogramService
    {
        /// <summary>
        /// Filtering and provision of histogram data
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="countOfBins"></param>
        /// <returns></returns>
        IReadOnlyCollection<IChartData<int>> ProvideChartData(DateTime startTime, DateTime endTime, int countOfBins);
    }
}