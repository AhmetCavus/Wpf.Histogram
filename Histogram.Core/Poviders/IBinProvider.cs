namespace Histogram.Core.Providers
{
    using Histogram.Core.Data;
    using System.Collections.Generic;

    /// <summary>
    /// A service for providing the bins
    /// </summary>
    public interface IBinProvider
    {
        /// <summary>
        /// Calculates the intervals and provides the bins
        /// </summary>
        /// <param name="rangeStart">The start of the range</param>
        /// <param name="rangeEnd">The end of the range</param>
        /// <param name="countOfBins">The total number of bins</param>
        /// <returns></returns>
        IReadOnlyList<IBinData> CreateBins(int rangeStart, int rangeEnd, int countOfBins);
    }
}
