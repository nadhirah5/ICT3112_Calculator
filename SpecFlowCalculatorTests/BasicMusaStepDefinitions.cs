using System;
using NUnit.Framework;
using ICT3112_Calculator;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class BasicMusaStepDefinitions
    {
        private readonly CalculatorContext _context;

        public BasicMusaStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        // Step Definition for calculating Failure Intensity
        [When(@"I have entered (.*) as the initial failure intensity \(λ₀\), (.*) as the total number of failures \(ν₀\), and (.*) as the average number of expected failures \(μ\(τ\)\) into the calculator")]
        public void WhenIHaveEnteredFailureIntensityAndExpectedFailures(int initialFailureIntensity, int totalFailures, int expectedFailures)
        {
            // Call the calculator function to compute failure intensity
            _context.Result = _context.Calculator.CalculateBasicFailureIntensity(initialFailureIntensity, expectedFailures, totalFailures);
        }

        [Then(@"the current failure intensity result should be ""(.*)""")]
        public void ThenTheFailureIntensityResultShouldBe(double expectedResult)
        {
            Assert.That(Math.Round(_context.Result, 4), Is.EqualTo(expectedResult));
        }

        // Step Definition for calculating Expected Failures
        [When(@"I have entered (.*) as the total number of failures \(ν₀\), (.*) as the initial failure intensity \(λ₀\), and (.*) as the time \(τ\) into the calculator")]
        public void WhenIHaveEnteredTotalFailuresInitialIntensityAndTime(int totalFailures, int initialFailureIntensity, int time)
        {
            // Call the calculator function to compute expected failures
            _context.Result = _context.Calculator.CalculateBasicExpectedFailures(totalFailures, initialFailureIntensity, time);
        }

        [Then(@"the average number of expected failures result should be ""(.*)""")]
        public void ThenTheExpectedFailuresResultShouldBe(double expectedResult)
        {
            Assert.That(Math.Round(_context.Result, 4), Is.EqualTo(expectedResult));
        }


    }
}
