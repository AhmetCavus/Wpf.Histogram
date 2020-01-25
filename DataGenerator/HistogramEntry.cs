using System;

namespace DataGenerator
{
    public class HistogramEntry
    {
        public int NumberValue { get; set; }
        public DateTime OccurrenceDate { get; set; }

        public override string ToString()
        {
            return $"Value: {NumberValue};On date: {OccurrenceDate}";
        }
    }
}