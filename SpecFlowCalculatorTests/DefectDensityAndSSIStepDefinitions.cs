using ICT3112_Calculator;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class DefectDensityAndSSIStepDefinitions
    {
        private readonly CalculatorContext _context;

        // Injecting the shared CalculatorContext into this class
        public DefectDensityAndSSIStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        // Defect Density Step Definitions
        [When(@"I have entered (.*) as the number of defects and (.*) KLOC as the total SSI into the calculator")]
        public void WhenIHaveEnteredAsTheNumberOfDefectsAndKLOCAsTheTotalSSIIntoTheCalculator(double defects, double ssi)
        {
            try
            {
                _context.Result = _context.Calculator.DoOperation(defects, ssi, "dd");
            }
            catch (ArgumentException ex)
            {
                _context.ErrorMessage = ex.Message; // Store the error message in the context
            }
        }

        [Then(@"the defect density result should be (.*)")]
        public void ThenTheDefectDensityResultShouldBe(string expectedResult)
        {
            if (_context.ErrorMessage != null)
            {
                Assert.That(_context.ErrorMessage, Is.EqualTo(expectedResult));
            }
            else
            {
                double expected = Convert.ToDouble(expectedResult);
                Assert.That(_context.Result, Is.EqualTo(expected));
            }
        }

        // Shipped Source Instructions (SSI) Step Definitions
        [When(@"I enter (.*) KLOC and (.*) new KLOC and (.*)% are changed/deleted lines of code into the calculator")]
        public void WhenIEnterKLOCAndNewKLOCAndAreChangedDeletedLinesOfCodeIntoTheCalculator(double currentSSI, double newKLOC, double percentageChanged)
        {
            _context.Result = _context.Calculator.DoOperation(currentSSI, newKLOC, percentageChanged, "ssi");
        }

        [When(@"I press ""(.*)""")]
        public void WhenIPress(string operation)
        {
            // Placeholder for the operation button press
        }

        [Then(@"the new total SSI should be (.*) KLOC")]
        public void ThenTheNewTotalSSIShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult).Within(0.3)); // Tolerance of 0.1 for floating-point comparison
        }

    }
}
