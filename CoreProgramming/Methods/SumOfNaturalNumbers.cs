using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class SumOfNaturalNumbers
    {
        public static void display()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Sum of first {number} natural numbers is {FindSum(number)}");
        }

        public static int FindSum(int number)
        {
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
