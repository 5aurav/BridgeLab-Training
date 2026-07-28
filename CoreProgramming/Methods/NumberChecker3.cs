using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class NumberChecker3
    {
        public static void display()
        {
            Console.Write("Enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int count = CountDigits(number);
            int[] digits = StoreDigits(number, count);
            int[] reverse = ReverseDigits(digits);

            Console.Write("Digits : ");
            PrintArray(digits);

            Console.Write("Reversed Digits : ");
            PrintArray(reverse);

            if (CompareArrays(digits, reverse))
            {
                Console.WriteLine("Palindrome Number");
            }
            else
            {
                Console.WriteLine("Not a Palindrome Number");
            }

            if (IsDuckNumber(digits))
            {
                Console.WriteLine("Duck Number");
            }
            else
            {
                Console.WriteLine("Not a Duck Number");
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

        public static int[] ReverseDigits(int[] digits)
        {
            int[] reverse = new int[digits.Length];

            int j = 0;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                reverse[j] = digits[i];
                j++;
            }

            return reverse;
        }

        public static bool CompareArrays(int[] array1, int[] array2)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsDuckNumber(int[] digits)
        {
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
