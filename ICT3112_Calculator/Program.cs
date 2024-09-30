namespace ICT3112_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Calculator _calculator = new Calculator();
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                string numInput3 = "";  // Third input for operations requiring 3 parameters
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter a valid number: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tf - Factorial (only first number is used)");
                Console.WriteLine("\tmtbf - Mean Time Between Failures (2 inputs required)");
                Console.WriteLine("\tav - Availability (2 inputs required)");
                Console.WriteLine("\tfi - Failure Intensity (3 inputs required: Initial Failure Intensity, Decay Factor, Time/Failures)");
                Console.WriteLine("\tef - Expected Failures (3 inputs required: Initial Failure Intensity, Decay Factor, CPU-hours)");
                Console.WriteLine("\tdd - Defect Density (2 inputs required: Defects and KLOC)");
                Console.WriteLine("\tssi - Shipped Source Instructions (3 inputs required: Current SSI, New KLOC, Percentage of Changed/Deleted Lines)");
                Console.WriteLine("\tta - Triangle Area (base and height required)");
                Console.WriteLine("\tca - Circle Area (only first number is used for radius)");
                Console.WriteLine("\tperm - Permutation (2 integers required)");
                Console.WriteLine("\tcomb - Combination (2 integers required)");

                Console.Write("Your option? ");
                string op = Console.ReadLine();

                // Check if the operation needs a second or third number
                if (op != "f" && op != "ca")
                {
                    // Ask the user to type the second number.
                    Console.Write("Type another number, and then press Enter: ");
                    numInput2 = Console.ReadLine();
                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter a valid number: ");
                        numInput2 = Console.ReadLine();
                    }

                    // Ask for the third number if the operation requires it (for Failure Intensity, Expected Failures, or SSI)
                    if (op == "fi" || op == "ef" || op == "ssi")
                    {
                        // Display helpful input descriptions for the user
                        if (op == "fi")
                        {
                            Console.WriteLine("\n--- For Failure Intensity (fi) ---");
                            Console.WriteLine("Initial Failure Intensity (λ₀): The starting failure intensity (failures per CPU-hour).");
                            Console.WriteLine("Decay Factor (b): The rate at which the failure intensity decreases over time.");
                            Console.WriteLine("Time or Failures (τ): The time in CPU-hours or number of failures experienced.");
                        }
                        else if (op == "ef")
                        {
                            Console.WriteLine("\n--- For Expected Failures (ef) ---");
                            Console.WriteLine("Initial Failure Intensity (λ₀): The starting failure intensity (failures per CPU-hour).");
                            Console.WriteLine("Decay Factor (b): The rate at which the failure intensity decreases over time.");
                            Console.WriteLine("CPU-hours (τ): The operational time in CPU-hours.");
                        }
                        else if (op == "ssi")
                        {
                            Console.WriteLine("\n--- For Shipped Source Instructions (ssi) ---");
                            Console.WriteLine("Current SSI: The current shipped source instructions in KLOC.");
                            Console.WriteLine("New KLOC: The new lines of code being added in the current release.");
                            Console.WriteLine("Percentage of Changed/Deleted Code: The percentage of lines in the current release that have been changed or deleted.");
                        }

                        Console.Write("Type a third number, and then press Enter: ");
                        numInput3 = Console.ReadLine();
                        double cleanNum3 = 0;
                        while (!double.TryParse(numInput3, out cleanNum3))
                        {
                            Console.Write("This is not valid input. Please enter a valid number: ");
                            numInput3 = Console.ReadLine();
                        }

                        // Perform the operation with three numbers
                        try
                        {
                            result = _calculator.DoOperation(cleanNum1, cleanNum2, cleanNum3, op);
                            if (double.IsNaN(result))
                            {
                                Console.WriteLine("This operation will result in a mathematical error.\n");
                            }
                            else Console.WriteLine("Your result: {0:0.##}\n", result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oh no! An exception occurred trying math.\n - Details: " + e.Message);
                        }
                    }
                    else  // Perform the operation with two numbers
                    {
                        try
                        {
                            result = _calculator.DoOperation(cleanNum1, cleanNum2, op);
                            if (double.IsNaN(result))
                            {
                                Console.WriteLine("This operation will result in a mathematical error.\n");
                            }
                            else Console.WriteLine("Your result: {0:0.##}\n", result);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oh no! An exception occurred trying math.\n - Details: " + e.Message);
                        }
                    }
                }
                else  // Operations that require only the first number (e.g., Factorial, Circle Area)
                {
                    try
                    {
                        result = _calculator.DoOperation(cleanNum1, 0, op);  // No second number is needed
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying math.\n - Details: " + e.Message);
                    }
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'q' and Enter to quit the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "q") endApp = true;

                Console.WriteLine("\n"); // Friendly line spacing.
            }
            return;
        }
    }
}
