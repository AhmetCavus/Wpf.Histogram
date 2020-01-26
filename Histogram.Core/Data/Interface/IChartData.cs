namespace Histogram.Core.Data
{
    /// <summary>
    /// Data container containing information for displaying any chart type
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public interface IChartData<TType>
    {
        /// <summary>
        /// The marker text for the Data below
        /// </summary>
        string Label { get; }

        /// <summary>
        /// The value for display in a chart 
        /// </summary>
        TType Data { get; }
    }
}
