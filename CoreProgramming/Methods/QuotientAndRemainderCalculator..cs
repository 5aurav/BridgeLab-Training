using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class QuotientAndRemainderCalculator
    {
        public static void display()
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter divisor: ");
            int divisor = int.Parse(Console.ReadLine());

            int[] result = FindRemainderAndQuotient(number, divisor);

            Console.WriteLine($"Quotient = {result[0]}");
            Console.WriteLine($"Remainder = {result[1]}");
        }

        public static int[] FindRemainderAndQuotient(int number, int divisor)
        {
            int quotient = number / divisor;
            int remainder = number % divisor;

            return new int[] { quotient, remainder };
        }
    }
}
