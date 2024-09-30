Feature: UsingCalculatorFactorial
    In order to conquer factorials
    As a math enthusiast
    I want to understand a variety of factorial calculations

# Testing factorial calculation for valid inputs (positive numbers, zero, and 1).
# Using the 'Scenario Outline' to test multiple inputs and expected results.

@Factorials
Scenario Outline: Calculating the factorial of a valid number
    Given I have a calculator
    When I have entered <number> into the calculator and press factorial
    Then the factorial result should be <expected>

    # Test cases for valid factorial calculations
    Examples:
      | number | expected             |
      | 0      | 1                   | # Factorial of zero is defined as 1
      | 1      | 1                   | # Factorial of 1 is 1
      | 5      | 120                 | # 5! = 5 * 4 * 3 * 2 * 1 = 120
      | 10     | 3628800             | # 10! = 10 * 9 * ... * 1 = 3628800

