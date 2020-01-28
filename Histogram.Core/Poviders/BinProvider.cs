namespace Histogram.Core.Providers
{
    using Histogram.Core.Data;
    using System;
    using System.Collections.Generic;

    public class BinProvider : IBinProvider
    {
        #region Methods
        public IReadOnlyList<IBinData> CreateBins(double rangeStart, double rangeEnd, int countOfBins)
        {
            if (rangeStart >= rangeEnd) throw new ArgumentException("Invalid parameter: The start value must be less than the end value");
            if (countOfBins <= 0) throw new ArgumentException("Invalid parameter: Count of bins must be grater than 0");

            var totalInterval = rangeEnd - rangeStart;
            if (countOfBins > totalInterval) throw new ArgumentException("Invalid parameter: The bin count cannot exceed the total interval");
            var binWidth = (double) totalInterval / countOfBins;
            return CreateBinDataList(rangeStart, rangeEnd, countOfBins, binWidth);
        }

        private List<IBinData> CreateBinDataList(double rangeStart, double rangeEnd, int countOfBins, double binWidth)
        {
            var binDataList = CreateEmptyBinDataList();
            binDataList.Add(new BinData(rangeStart, rangeStart + binWidth));
            for(int index = 1; index < countOfBins; index++)
            {
                var previousBin = binDataList[index - 1];
                binDataList.Add(new BinData(previousBin.Range.End +1, previousBin.Range.End + binWidth));
            }
            return binDataList;
        }

        private List<IBinData> CreateEmptyBinDataList() => new List<IBinData>();

        #endregion
    }
}