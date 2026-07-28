using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class NumberChecker2
    {
        public static void display()
        {
            Console.Write("Enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int count = CountDigits(number);
            int[] digits = StoreDigits(number, count);

            Console.WriteLine("Digit Count : " + count);
            Console.WriteLine("Sum of Digits : " + SumOfDigits(digits));
            Console.WriteLine("Sum of Squares : " + SumOfSquares(digits));

            if (IsHarshad(number, digits))
            {
                Console.WriteLine("Harshad Number");
            }
            else
            {
                Console.WriteLine("Not a Harshad Number");
            }

            int[,] frequency = FindFrequency(digits);

            Console.WriteLine("\nDigit\tFrequency");

            for (int i = 0; i < 10; i++)
            {
                if (frequency[i, 1] > 0)
                {
                    Console.WriteLine(frequency[i, 0] + "\t" + frequency[i, 1]);
                }
            }
        }

        public static int CountDigits(int number)
        {
            int count = 0;

            while (number > 0)
            {
                count++;
                number /= 10;
            }

            return count;
        }

        public static int[] StoreDigits(int number, int count)
        {
            int[] digits = new int[count];

            for (int i = count - 1; i >= 0; i--)
            {
                digits[i] = number % 10;
                number /= 10;
            }

            return digits;
        }

        public static int SumOfDigits(int[] digits)
        {
            int sum = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                sum += digits[i];
            }

            return sum;
        }

        public static int SumOfSquares(int[] digits)
        {
            int sum = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                sum += (int)Math.Pow(digits[i], 2);
            }

            return sum;
        }

        public static bool IsHarshad(int number, int[] digits)
        {
            int sum = SumOfDigits(digits);

            return number % sum == 0;
        }

        public static int[,] FindFrequency(int[] digits)
        {
            int[,] frequency = new int[10, 2];

            for (int i = 0; i < 10; i++)
            {
                frequency[i, 0] = i;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                frequency[digits[i], 1]++;
            }

            return frequency;
        }
    }
}
