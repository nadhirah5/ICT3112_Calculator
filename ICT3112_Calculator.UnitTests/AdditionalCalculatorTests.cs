
using Moq; // Include Moq namespace for mocking

namespace ICT3112_Calculator.UnitTests
{
    [TestFixture]
    public class AdditionalCalculatorTests
    {
        // Private fields for Calculator and Mock IFileReader
        private Calculator _calculator;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            // Create a new Mock object for IFileReader
            _mockFileReader = new Mock<IFileReader>();

            // Set up the mock to return specific values for the Read method when called with "MagicNumbers.txt"
            _mockFileReader.Setup(fr => fr.Read("MagicNumbers.txt"))
                           .Returns(new string[] { "42", "42" }); // Mocked return values

            // Initialize the Calculator
            _calculator = new Calculator();
        }

        [Test]
        public void GenMagicNum_ValidInput_ReturnsExpectedValue()
        {
            // Act
            double result = _calculator.GenMagicNum(1, _mockFileReader.Object); // Pass in the mock object

            // Assert
            Assert.That(result, Is.EqualTo(84)); // Since 42 * 2 = 84
        }

        [Test]
        public void GenMagicNum_NegativeIndex_ReturnsDefaultValue()
        {
            // Act
            double result = _calculator.GenMagicNum(-1, _mockFileReader.Object); // Pass in the mock object

            // Assert
            Assert.That(result, Is.EqualTo(0)); // Default value as per the GenMagicNum function logic
        }

        [Test]
        public void GenMagicNum_IndexOutOfRange_ReturnsDefaultValue()
        {
            // Act
            double result = _calculator.GenMagicNum(10, _mockFileReader.Object); // Pass in the mock object

            // Assert
            Assert.That(result, Is.EqualTo(0)); // Default value as per the GenMagicNum function logic
        }

        [Test]
        public void GenMagicNum_ValidInput_ReturnsExpectedValue_WhenFileContainsDifferentValues()
        {
            // Arrange: Update mock setup with different values for this specific test
            _mockFileReader.Setup(fr => fr.Read("MagicNumbers.txt"))
                           .Returns(new string[] { "50", "60", "70", "80" }); // New mock data

            // Act
            double result = _calculator.GenMagicNum(2, _mockFileReader.Object); // Index 2, value should be 70

            // Assert
            Assert.That(result, Is.EqualTo(140)); // 70 * 2 = 140
        }
    }
}
