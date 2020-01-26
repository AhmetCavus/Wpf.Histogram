namespace Histogram.Core.Data
{
    /// <summary>
    /// The range containing start and end values
    /// </summary>
    public interface IInterval
    {
        /// <summary>
        /// The start of the range
        /// </summary>
        int Start { get; }
        
        /// <summary>
        /// The end of the range 
        /// </summary>
        int End { get; }
    }
}
