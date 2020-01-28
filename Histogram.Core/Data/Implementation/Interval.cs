namespace Histogram.Core.Data
{
    public class Interval : IInterval
    {
        public double Start { get; }
        public double End { get; }

        public Interval(double start, double end)
        {
            Start = start;
            End = end;
        }

    }
}
