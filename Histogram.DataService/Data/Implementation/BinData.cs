namespace Histogram.Core.Data
{
    public class BinData : IBinData
    {
        public IInterval Range { get; }
        public int Count { get; set; }

        public BinData(int lowerBound, int upperBound)
        {
            Range = new Interval(lowerBound, upperBound);
        }

        public override string ToString() =>
            $"Lower bound: {Range.Start}; Upper bound: {Range.End}; Count: {Count}";
    }
}
