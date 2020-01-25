namespace Histogram.Unittest.HistogramCore
{
    using Histogram.Core.Data;
    using Histogram.Core.Poviders;
    using NUnit.Framework;
    using System;

    class BinProviderTest
    {
        static object[] BinProvider_CreateBins_Cases =
        {
            new object[]
            {
                new Interval(-1000, 1000),
                3,
                new Interval[3]
                {
                    new Interval(-1000, -334),
                    new Interval(-333, 332),
                    new Interval(333, 1000)
                }
            },
            new object[]
            {
                new Interval(0, 1000),
                2,
                new Interval[2]
                {
                    new Interval(0, 500),
                    new Interval(501, 1000)
                }
            },
            new object[]
            {
                new Interval(-1000, 1000),
                2,
                new Interval[2]
                {
                    new Interval(-1000, 0),
                    new Interval(1, 1000)
                }
            },
            new object[] 
            { 
                new Interval(-1000, 1000), 
                4, 
                new Interval[4] 
                { 
                    new Interval(-1000, -500), 
                    new Interval(-499, 0), 
                    new Interval(1, 500), 
                    new Interval(501, 1000) 
                } 
            }
        };

        [TestCaseSource(nameof(BinProvider_CreateBins_Cases))]
        public void BinProvider_CreateBins_ReturnIReadOnlyCollection_IsTrue(Interval testRange, int countOfBins, Interval[] expectedResults)
        {
            // Arrange
            var sut = new BinProvider();

            // Act
            var results = sut.CreateBins(testRange.Start, testRange.End, countOfBins);

            // Assert
            for (int index = 0; index < results.Count; index++)
            {
                var result = results[index];
                var expectedResult = expectedResults[index];

                Assert.IsTrue(result.Range.Start == expectedResult.Start && result.Range.End == expectedResult.End);
            }
        }

        [TestCase(2000, 1000, 4)]
        [TestCase(0, 1000, 0)]
        [TestCase(0, 1000, 1500)]
        [TestCase(-400, 400, 801)]
        public void BinProvider_CreateBins_ReturnIReadOnlyCollection_ThrowsArgumentException(int rangeStart, int rangeEnd, int countOfBins)
        {
            // Arrange
            var sut = new BinProvider();

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                sut.CreateBins(rangeStart, rangeEnd, countOfBins);
            });          
        }
    }
}