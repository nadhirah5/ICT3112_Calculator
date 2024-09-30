// CalculatorContext.cs
using ICT3112_Calculator;

public class CalculatorContext
{
    public Calculator Calculator { get; set; }
    public double Result { get; set; }
    public double InitialFailureIntensity { get; set; }
    public double DecayFactor { get; set; }
    public double Time { get; set; }
    public string ErrorMessage { get; set; }
}
