
namespace Histogram.Unittest.DataGenerator
{
    using global::DataGenerator;
    using NUnit.Framework;

    class HistogramDataGeneratorTest
    {
        [Test]
        public void HistogramDataGenerator_GetRandomHistogramData_ReturnIReadOnlyCollection_IsNotNull()
        {
            // Arrange

            // Act
            var result = HistogramDataGenerator.GetRandomHistogramData();

            // Assert
            Assert.IsNotNull(result);
        }

    }
}