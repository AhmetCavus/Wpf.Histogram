namespace Histogram.Core.Data
{
    public interface IBinData
    {
        IInterval Range { get; }
        int Count { get; set; }
    }
}
