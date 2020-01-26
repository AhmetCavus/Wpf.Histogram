namespace Histogram.Core.Data
{
    public class ChartData<TType> : IChartData<TType>
    {
        public string Label { get; }

        public TType Data { get; }

        public ChartData(string label, TType data)
        {
            Label = label;
            Data = data;
        }
    }
}
