namespace Histogram.Unittest.HistogramCore
{
    using Histogram.Core.Providers;
    using Histogram.Core.Services;
    using NUnit.Framework;
    using System;
    using System.Linq;
    public class HistogramServiceTest
    {
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(99)]
        [TestCase(200)]
        public void HistogramService_ProvideChartData_ReturnIReadOnlyCollection_IsTrue(int countOfBins)
        {
            // Arrange
            const int CuntOfGeneratedNumbers = 3000;
            var sut = new HistogramService(new BinProvider());

            // Act
            var results = sut.ProvideChartData(DateTime.Now.AddYears(-1), DateTime.Now, countOfBins);
            var totalCount = results.Sum(result => result.Data);

            // Assert
            Assert.IsTrue(totalCount == CuntOfGeneratedNumbers);
        }

        [Test]
        public void HistogramService_ProvideChartData_ReturnIReadOnlyCollection_ThrowsArgumentException()
        {
            var sut = new HistogramService(new BinProvider());

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                sut.ProvideChartData(DateTime.Now, DateTime.Now.AddSeconds(-1), countOfBins: 4);
            });
        }
    }
}