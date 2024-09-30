Feature: UsingCalculatorMusaLogarithmic

User Story 3 - Failure Intensity Calculation using Musa Logarithmic Model: 
As a system quality engineer, 
I want to calculate the failure intensity using the Musa Logarithmic model 
so that I can predict the failure rate based on system reliability and operational time.

Acceptance Criteria:

The calculator should accept inputs for initial failure intensity, execution time, and the number of failures experienced.
The output should provide the failure intensity based on the Musa model.

User Story 4 - Expected Failures Calculation using Musa Logarithmic Model: 
As a system quality engineer, 
I want to calculate the expected number of failures over a given time period using the Musa Logarithmic model 
so that I can estimate the system’s reliability over time.

Acceptance Criteria:

The calculator should accept inputs for operational time and system parameters.
The output should provide the expected number of failures based on the Musa model.
A short summary of the feature

@Reliability 
Scenario: Calculating Current Failure Intensity Using Musa Logarithmic model
	Given I have a calculator
	When I have entered <value1> failures/CPU-hour and <value2> failure intensity decay and <value3> failures experienced currently into the calculator and press CFI_LOG
	Then the current failure log intensity result should be <value4> /CPU-hour

Examples: 
	| value1 | value2 | value3 | value4 |
	| 10     | 0.02   | 50      | 3.68    |


@Reliability
Scenario: Calculate Expected Failures Using Musa Logarithmic model
	Given I have a calculator
	When I have entered <value1> intitial failure intensity and <value2> failure intensity decay and <value3> CPU-hours into the calculator and press AEF_LOG
	Then the average number of failures should be <value4> failures

Examples: 
| value1 | value2 | value3 | value4 |
| 10     | 0.02   | 10     | 55     |
| 10     | 0.02   | 100    | 152    |
| 10     | 0      | 10     | positive_infinity     | // 0 decay rate
| 0    | 2      | 10     | 0    |					// 0 initial failure intensity
| 1   | 1      | 0     | 0    |						// 0 cpu-hours


