using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator
{
    public static class HistogramDataGenerator
    {
        private static readonly int DATA_SET_COUNT = 3000;
        private static readonly int LOWER_BOUND = -1000;
        private static readonly int UPPER_BOUND = 1000;

        public static IReadOnlyCollection<HistogramEntry> GetRandomHistogramData()
        {
            var random = new Random((int)DateTime.UtcNow.Ticks);
            var result = Enumerable.Range(0, DATA_SET_COUNT)
                                    .Select(currentIndex => new HistogramEntry
                                    {
                                        NumberValue = random.Next(UPPER_BOUND - LOWER_BOUND + 1) + LOWER_BOUND,
                                        OccurrenceDate = new DateTime(2020, 1, 1).AddMinutes(Math.PI * currentIndex)
                                    }).ToList();

            return result.AsReadOnly();
        }
    }
}
