using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Finally
    {
        public static void Run()
        {
            try
            {
                Console.Write("Enter first integer: ");
                int first = int.Parse(Console.ReadLine());

                Console.Write("Enter second integer: ");
                int second = int.Parse(Console.ReadLine());

                int result = first / second;

                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }
        }
    }
}
