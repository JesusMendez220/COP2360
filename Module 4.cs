using System;

namespace DivisionConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            string input1 = Console.ReadLine();

            Console.Write("Enter the second number: ");
            string input2 = Console.ReadLine();

            PerformDivision(input1, input2);

            // To experiment with unhandled exceptions,
            // comment out PerformDivision and uncomment the line below:
            // PerformDivisionWithoutTryCatch(input1, input2);
        }

        static void PerformDivision(string str1, string str2)
        {
            try
            {
                int num1 = int.Parse(str1);
                int num2 = int.Parse(str2);

                int result = num1 / num2;

                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: One or both inputs are not valid integers.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: One or both numbers are too large or too small for an integer.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }

        // Method without try-catch to demonstrate unhandled exceptions
        static void PerformDivisionWithoutTryCatch(string str1, string str2)
        {
            int num1 = int.Parse(str1);
            int num2 = int.Parse(str2);

            int result = num1 / num2;

            Console.WriteLine($"Result: {result}");
        }
    }
}
