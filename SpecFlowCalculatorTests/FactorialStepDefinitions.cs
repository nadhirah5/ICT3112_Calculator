using ICT3112_Calculator;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class FactorialStepDefinitions
    {
        private readonly CalculatorContext _context;

        public FactorialStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) into the calculator and press factorial")]
        public void WhenIHaveEnteredAndPressedFactorial(double number)
        {
            _context.Result = _context.Calculator.Factorial(number);
        }

        [Then(@"the factorial result should be (.*)")]
        public void ThenTheFactorialResultShouldBe(double p0)
        {
            Assert.That(_context.Result, Is.EqualTo(p0));
        }
    }
}
