namespace Histogram.Unittest.HistogramCore
{
    using Histogram.Core.Poviders;
    using Histogram.Core.Services;
    using NUnit.Framework;
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
            var results = sut.ProvideChartData(sut.StartDate.Value, sut.EndDate.Value, countOfBins);
            var totalCount = results.Sum(result => result.Data);

            // Assert
            Assert.IsTrue(totalCount == CuntOfGeneratedNumbers);
        }
    }
}