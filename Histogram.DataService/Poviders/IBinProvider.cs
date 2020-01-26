namespace Histogram.Core.Providers
{
    using Histogram.Core.Data;
    using System.Collections.Generic;

    public interface IBinProvider
    {
        IReadOnlyList<IBinData> CreateBins(int rangeStart, int rangeEnd, int countOfBins);
    }
}
