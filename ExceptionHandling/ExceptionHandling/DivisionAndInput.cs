using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class DivisionAndInput
    {
        public static void Run()
        {
            try
            {
                Console.Write("Enter numerator: ");
                int numerator = int.Parse(Console.ReadLine());

                Console.Write("Enter denominator: ");
                int denominator = int.Parse(Console.ReadLine());

                int result = numerator / denominator;

                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format");
            }
        }
    }
}
