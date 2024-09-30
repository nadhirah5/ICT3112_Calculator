Feature: UsingCalculatorDefectDensityAndSSI
  In order to assess system quality and monitor codebase growth after releases
  As a system quality engineer
  I want to calculate the defect density and new total SSI using a calculator.

  # Defect Density Calculation
  @DefectDensity
  Scenario: Calculate Defect Density with valid inputs in KLOC
    Given I have a calculator
    When I have entered <defects> as the number of defects and <ssi> KLOC as the total SSI into the calculator
    And I press "Defect Density"
    Then the defect density result should be <result>

  Examples:
    | defects | ssi   | result | 
    | 50      | 5     | 10     | # 50 defects, 5 KLOC = 10 defects/KLOC
    | 100     | 10    | 10     | # 100 defects, 10 KLOC = 10 defects/KLOC
    | 5       | 2.5   | 2      | # 5 defects, 2.5 KLOC = 2 defects/KLOC
    | 0       | 5     | 0      | # No defects, 5 KLOC = 0 defects/KLOC
    | 50      | 0     | Total SSI cannot be zero.  | # Edge case: Total SSI cannot be zero, expect error

  # Shipped Source Instructions (SSI) Calculation
  @SSI
  Scenario: Calculate SSI for a New Release with valid inputs
    Given I have a calculator
    When I enter <value1> KLOC and <value2> new KLOC and <value3>% are changed/deleted lines of code into the calculator
    And I press "SSI"
    Then the new total SSI should be <value4> KLOC

  Examples:
    | value1 | value2 | value3 | value4 |
    | 100    | 10     | 20     | 90     | # 20% of 100 KLOC changed/deleted + 10 new KLOC = 90 KLOC
    | 50     | 20     | 10     | 65     | # 10% of 50 KLOC changed/deleted + 20 new KLOC = 65 KLOC
    | 100    | 50     | 0      | 150    | # No changes, 50 new KLOC = 150 KLOC
    | 150    | 0      | 10     | 135    | # 10% of 150 KLOC changed/deleted = 135 KLOC
    | 500    | 0      | 100    | 0      | # 100% of 500 KLOC changed/deleted = 0 KLOC
    | 100.5  | 25.75  | 10     | 115.95 | # 10% of 100.5 KLOC changed/deleted + 25.75 new KLOC = 115.95 KLOC
    | 100    | 1000   | 10     | 1090   | # 10% of 100 KLOC changed/deleted + 1000 new KLOC = 1090 KLOC
    | 1000   | 100    | 90     | 200    | # 90% of 1000 KLOC changed/deleted + 100 new KLOC = 200 KLOC
