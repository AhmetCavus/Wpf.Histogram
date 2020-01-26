namespace Histogram.Core.Data
{
    /// <summary>
    /// A bin for the histogram
    /// </summary>
    public interface IBinData
    {
        /// <summary>
        /// Specifies the interval range for which the frequency is valid
        /// </summary>
        IInterval Range { get; }

        /// <summary>
        /// The frequency number in the interval
        /// </summary>
        int Count { get; set; }
    }
}
