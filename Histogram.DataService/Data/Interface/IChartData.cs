namespace Histogram.Core.Data
{
    public interface IChartData<TType>
    {
        string Label { get; }
        TType Data { get; }
    }
}
