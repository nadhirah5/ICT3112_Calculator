using ICT3112_Calculator;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class MTBF_AvailabilityStepDefinitions
    {
        private readonly CalculatorContext _context;

        public MTBF_AvailabilityStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndPressedMTBF(double operationalHours, double failures)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateMTBF(operationalHours, failures);
            }
            catch (ArgumentException ex)
            {
                _context.ErrorMessage = ex.Message;
            }
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndPressedAvailability(double totalHours, double downtime)
        {
            _context.Result = _context.Calculator.CalculateAvailability(totalHours, downtime);
        }

        [Then(@"the MTBF result should be ""(.*)""")]
        public void ThenTheMTBFResultShouldBe(string expectedResult)
        {
            double expected = Convert.ToDouble(expectedResult);
            Assert.That(_context.Result, Is.EqualTo(expected));
        }

        [Then(@"the availability result should be ""(.*)""")]
        public void ThenTheAvailabilityResultShouldBe(string expectedResult)
        {
            double expected = Convert.ToDouble(expectedResult);
            double actual = Math.Round(_context.Result, 5);
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Then(@"an error should be thrown with the message ""(.*)""")]
        public void ThenAnErrorShouldBeThrown(string expectedMessage)
        {
            Assert.That(_context.ErrorMessage, Is.EqualTo(expectedMessage));
        }
    }
}
