using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class LargestAndShortestInNumber2
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            long originalNum = Math.Abs(long.Parse(Console.ReadLine() ?? "0"));
            long num = originalNum;

            int maxDigit = 10;
            long[] digits = new long[maxDigit];
            int idx = 0;

            if (num == 0) digits[idx++] = 0;

            while (num > 0)
            {
                if (idx == maxDigit)
                {
                    maxDigit += 10;
                    long[] temp = new long[maxDigit];
                    Array.Copy(digits, temp, digits.Length);
                    digits = temp;
                }

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
