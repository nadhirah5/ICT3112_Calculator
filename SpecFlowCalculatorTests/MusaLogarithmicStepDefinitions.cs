using NUnit.Framework;
using Reqnroll;
using System;


namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class MusaLogarithmicStepDefinition
    {
        private readonly CalculatorContext _context;

        public MusaLogarithmicStepDefinition(CalculatorContext context)
        {
            _context = context;
        }
        [When(@"I have entered (.*) failures/CPU-hour and (.*) failure intensity decay and (.*) failures experienced currently into the calculator and press CFI_LOG")]
        public void WhenIHaveEnteredAndIntoTheCalculatorForCurrentFailureIntensityLog(double p0, double p1, double p2)
        {

            _context.Result = _context.Calculator.CalculateFailureIntensity(p0, p1, p2);

        }
        [Then(@"the current failure log intensity result should be (.*) /CPU-hour")]
        public void ThenTheLogFailureIntensityResultShouldBeOnTheScreen(double expected)
        {
            Assert.That(_context.Result, Is.EqualTo(expected));
        }
        [When(@"I have entered (.*) intitial failure intensity and (.*) failure intensity decay and (.*) CPU-hours into the calculator and press AEF_LOG")]
        public void WhenIHaveEnteredAndIntoTheCalculatorForAverageFailureLog(double p0, double p1, double p2)
        {

            _context.Result = _context.Calculator.CalculateExpectedFailures(p0, p1, p2);

        }
        [Then(@"the average number of failures should be (.*) failures")]
        public void ThenTheLogAverageFailureResultShouldBeOnTheScreen(string expected)
        {
            double expectedValue;

            // Check for special cases like positive infinity
            if (expected == "positive_infinity")
            {
                expectedValue = double.PositiveInfinity;
            }
            else
            {
                // Convert the expected value to a double
                expectedValue = Convert.ToDouble(expected);
            }

            // Assert the result
            Assert.That(_context.Result, Is.EqualTo(expectedValue));
        }


    }
}