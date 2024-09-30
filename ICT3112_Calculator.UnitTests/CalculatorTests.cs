namespace ICT3112_Calculator.UnitTests;

public class CalculatorTests
{
    private Calculator _calculator;
    [SetUp]
    public void Setup()
    {
        // Arrange
        _calculator = new Calculator();
    }
    [Test]
    public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
    {
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    //--------------------Q13------------------------------------------------------

    [Test]
    public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
    {
        // Act
        double result = _calculator.Subtract(20, 10);
        // Assert
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
    {
        // Act
        double result = _calculator.Multiply(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(200));
    }

    [Test]
    public void Divide_WhenDividingTwoNumbers_ResultEqualToQuotient()
    {
        // Act
        double result = _calculator.Divide(20, 10);
        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    //--------------------Q14a------------------------------------------------------

    [Test]
    public void Divide_WithZerosAsInputs_ResultThrowArgumentException()
    {
        // Act & Assert
        Assert.That(() => _calculator.Divide(0, 0), Throws.ArgumentException);
    }

    //--------------------Q14b------------------------------------------------------

    [Test]
    [TestCase(0, 0)]
    [TestCase(0, 10)]
    [TestCase(10, 0)]
    public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
    {
        // Act & Assert
        Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
    }

    //--------------------Q15------------------------------------------------------

    [Test]
    [TestCase(0, 1)]  // 0! = 1
    [TestCase(1, 1)]  // 1! = 1
    [TestCase(5, 120)]  // 5! = 120
    public void Factorial_WhenCalculatingFactorial_ResultEqualToExpected(int input, double expected)
    {
        // Act
        double result = _calculator.Factorial(input);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Factorial_WhenInputIsNegative_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.That(() => _calculator.Factorial(-1), Throws.ArgumentException);
    }

    //--------------------Q16a------------------------------------------------------

    [Test]
    public void CalculateTriangleArea_WithBaseAndHeight_ReturnsCorrectArea()
    {
        // Act
        double result = _calculator.CalculateTriangleArea(10, 5);

        // Assert
        Assert.That(result, Is.EqualTo(25));
    }


    //--------------------Q16b------------------------------------------------------ negative handling

    [Test]
    public void CalculateCircleArea_WithRadius_ReturnsCorrectArea()
    {
        // Act
        double result = _calculator.CalculateCircleArea(5);

        // Assert
        Assert.That(result, Is.EqualTo(Math.PI * 25)); // 25 is 5^2
    }

    //--------------------Q17a------------------------------------------------------

    [Test]
    public void UnknownFunctionA_WhenGivenTest0_Result() // PermutationWithoutRepetition_SameValues_ReturnsFactorial
    {
        double result = _calculator.UnknownFunctionA(5, 5);
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest1_Result() // PermutationWithoutRepetition_OneLess_ReturnsFactorial
    {
        double result = _calculator.UnknownFunctionA(5, 4);
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest2_Result() // PermutationWithoutRepetition_TwoLess_ReturnsHalfFactorial
    {
        double result = _calculator.UnknownFunctionA(5, 3);
        Assert.That(result, Is.EqualTo(60));
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException() // PermutationWithoutRepetition_InvalidInputs_ThrowsArgumentException
    {
        Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
    }

    [Test]
    public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException() // PermutationWithoutRepetition_InvalidInputs_ThrowsArgumentException
    {
        Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
    }

    //--------------------Q17b------------------------------------------------------

    [Test]
    public void UnknownFunctionB_WhenGivenTest0_Result() // Combination_SameValues_ReturnsOne
    {
        double result = _calculator.UnknownFunctionB(5, 5);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void UnknownFunctionB_WhenGivenTest1_Result() // Combination_OneLess_ReturnsX
    {
        double result = _calculator.UnknownFunctionB(5, 4);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void UnknownFunctionB_WhenGivenTest2_Result() // Combination_TwoLess_ReturnsExpectedCombination
    {
        double result = _calculator.UnknownFunctionB(5, 3);
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException() // Combination_InvalidInputs_ThrowsArgumentException
    {
        Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
    }

    [Test]
    public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException() // Combination_InvalidInputs_ThrowsArgumentException
    {
        Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
    }


}