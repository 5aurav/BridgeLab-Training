using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class NestedTryCatch
    {
        public static void Run()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };

            try
            {
                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                try
                {
                    int value = numbers[index];

                    Console.Write("Enter divisor: ");
                    int divisor = int.Parse(Console.ReadLine());

                    int result = value / divisor;

                    Console.WriteLine($"Result: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid array index!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
