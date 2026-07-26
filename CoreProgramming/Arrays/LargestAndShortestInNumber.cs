using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class LargestAndShortestInNumber
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            long num = Math.Abs(long.Parse(Console.ReadLine() ?? "0"));

            long[] digits = new long[10];
            int idx = 0;

            while (num > 0 && idx < 10)
            {
                digits[idx++] = num % 10;
                num /= 10;
            }

            long max1 = 0, max2 = 0;
            for (int i = 0; i < idx; i++)
            {
                if (digits[i] > max1) { max2 = max1; max1 = digits[i]; }
                else if (digits[i] > max2 && digits[i] < max1) max2 = digits[i];
            }

            Console.WriteLine($"Largest: {max1}\nSecond Largest: {max2}");
        }
    }
}
