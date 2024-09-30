Feature: UsingCalculatorAvailability
    In order to calculate MTBF and Availability
    As someone who struggles with math
    I want to be able to use my calculator to do this

@MTBF
Scenario: Calculating MTBF
    Given I have a calculator
    When I have entered 1000 and 50 into the calculator and press MTBF
    Then the MTBF result should be "20"

@Availability
Scenario: Calculating Availability
    Given I have a calculator
    When I have entered 8760 and 10 into the calculator and press Availability
    Then the availability result should be "0.99886"

@Availability
Scenario: Calculating Availability with higher downtime
    Given I have a calculator
    When I have entered 8760 and 100 into the calculator and press Availability
    Then the availability result should be "0.9886"
    
@MTBF
Scenario: Calculating MTBF with higher failure rate
    Given I have a calculator
    When I have entered 5000 and 200 into the calculator and press MTBF
    Then the MTBF result should be "25"


@MTBF
Scenario: Calculating MTBF with large operational hours
    Given I have a calculator
    When I have entered 1000000 and 1000 into the calculator and press MTBF
    Then the MTBF result should be "1000"

@Availability
Scenario: Calculating Availability with zero downtime
    Given I have a calculator
    When I have entered 8760 and 0 into the calculator and press Availability
    Then the availability result should be "1.0"

@MTBF
Scenario: Calculating MTBF with zero failures
    Given I have a calculator
    When I have entered 1000 and 0 into the calculator and press MTBF
    Then an error should be thrown with the message "Failures cannot be zero."
