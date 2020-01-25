
namespace Histogram.Core.Poviders
{
    using Histogram.Core.Data;
    using System;
    using System.Collections.Generic;

    public class BinProvider : IBinProvider
    {
        public IReadOnlyList<IBinData> CreateBins(int rangeStart, int rangeEnd, int countOfBins)
        {
            if (rangeStart >= rangeEnd) throw new ArgumentException("Invalid parameter: The start value must be less than the end value");
            if (countOfBins <= 0) throw new ArgumentException("Invalid parameter: Count of bins must be grater than 0");

            var totalInterval = CalculateTotalInterval(rangeStart, rangeEnd);
            if (countOfBins > totalInterval) throw new ArgumentException("Invalid parameter: The bin count cannot exceed the total interval");

            var binRange = totalInterval / countOfBins;
            var binDataList = CreateBinDataList();

            int stepToNextBin = 0;
            for (int index = rangeStart; index < rangeEnd; index += binRange)
            {
                var lowerBound = index + stepToNextBin;
                var upperBound = index + binRange;
                stepToNextBin = 1;
                
                if (IsExceeding(nextUpperBound: upperBound + binRange, rangeEnd))
                {
                    binDataList.Add(new BinData(lowerBound, rangeEnd));
                    break;
                }
                else binDataList.Add(new BinData(lowerBound, upperBound));

            }
            return binDataList;
        }

        private int CalculateTotalInterval(int rangeStart, int rangeEnd) =>
            Math.Abs(rangeStart - rangeEnd);

        private List<IBinData> CreateBinDataList() => new List<IBinData>();

        private bool IsExceeding(float nextUpperBound, float rangeEnd) => nextUpperBound > rangeEnd;

    }
}
