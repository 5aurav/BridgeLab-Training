using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class ChocolateDistribution
    {
        public static void display()
        {
            Console.Write("Enter total chocolates: ");
            int chocolates = int.Parse(Console.ReadLine());

            Console.Write("Enter number of children: ");
            int children = int.Parse(Console.ReadLine());

            int[] result = FindRemainderAndQuotient(chocolates, children);

            Console.WriteLine($"Each child gets {result[0]} chocolates");
            Console.WriteLine($"Remaining chocolates = {result[1]}");
        }

        public static int[] FindRemainderAndQuotient(int number, int divisor)
        {
            int quotient = number / divisor;
            int remainder = number % divisor;

            return new int[] { quotient, remainder };
        }
    }
}
