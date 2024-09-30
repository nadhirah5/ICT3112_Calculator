Feature: UsingCalculatorBasicMusa
  In order to calculate the Basic Musa model's failure intensities and expected failures
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

  @FailureIntensity
  Scenario Outline: Calculating current failure intensity using the Basic Musa model
    Given I have a calculator
    When I have entered <initialFailureIntensity> as the initial failure intensity (λ₀), <totalFailures> as the total number of failures (ν₀), and <expectedFailures> as the average number of expected failures (μ(τ)) into the calculator
    Then the current failure intensity result should be "<expectedResult>"

    Examples:
      | initialFailureIntensity | totalFailures | expectedFailures | expectedResult |
      | 1000                    | 2000          | 1000             | 500            | # Basic case: Failure intensity should be half of initial when expected failures equals half the total failures
      | 1000                    | 1000          | 0                | 1000           | # No failures experienced, failure intensity remains the same
      | 1000                    | 1000          | 1000             | 0              | # All failures experienced, failure intensity should be zero
      | 1000                    | 2000          | 0                | 1000           | # No expected failures yet, failure intensity remains initial
      | 1000                    | 2000          | 1999             | 0.5            | # Close to all failures experienced

  @ExpectedFailures
  Scenario Outline: Calculating the average number of expected failures using the Basic Musa model
    Given I have a calculator
    When I have entered <totalFailures> as the total number of failures (ν₀), <initialFailureIntensity> as the initial failure intensity (λ₀), and <time> as the time (τ) into the calculator
    Then the average number of expected failures result should be "<expectedResult>"

    Examples:
      | totalFailures | initialFailureIntensity | time  | expectedResult |
      | 2000          | 1000                    | 15    | 1998.8938       | # Basic case: moderate time and total failures
      | 2000          | 1000                    | 100   | 2000           | # At large time, expected failures approach total failures
      | 1000          | 1000                    | 0     | 0              | # At time zero, no expected failures
      | 1000          | 1000                    | 10    | 999.9546         | # Small decay factor, large time
      | 1000          | 500                     | 5     | 917.915       | # Half initial failure intensity
      | 500           | 1000                    | 5     | 499.9773        | # Higher initial failure intensity than total failures
