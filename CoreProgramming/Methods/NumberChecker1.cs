using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class NumberChecker1
    {
        public static void display()
        {
            Console.Write("Enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int count = CountDigits(number);
            int[] digits = StoreDigits(number, count);

            Console.WriteLine("Digit Count : " + count);
            Console.WriteLine("Duck Number : " + IsDuckNumber(digits));
            Console.WriteLine("Armstrong Number : " + IsArmstrong(number, digits));
            FindLargestSecondLargest(digits);
            FindSmallestSecondSmallest(digits);
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

        public static bool IsArmstrong(int number, int[] digits)
        {
            int sum = 0;

            foreach (int digit in digits)
            {
                sum += (int)Math.Pow(digit, digits.Length);
            }

            return sum == number;
        }

        public static void FindLargestSecondLargest(int[] digits)
        {
            int largest = Int32.MinValue;
            int secondLargest = Int32.MinValue;

            foreach (int digit in digits)
            {
                if (digit > largest)
                {
                    secondLargest = largest;
                    largest = digit;
                }
                else if (digit > secondLargest && digit != largest)
                {
                    secondLargest = digit;
                }
            }

            Console.WriteLine("Largest Digit : " + largest);
            Console.WriteLine("Second Largest Digit : " + secondLargest);
        }

        public static void FindSmallestSecondSmallest(int[] digits)
        {
            int smallest = Int32.MaxValue;
            int secondSmallest = Int32.MaxValue;

            foreach (int digit in digits)
            {
                if (digit < smallest)
                {
                    secondSmallest = smallest;
                    smallest = digit;
                }
                else if (digit < secondSmallest && digit != smallest)
                {
                    secondSmallest = digit;
                }
            }

            Console.WriteLine("Smallest Digit : " + smallest);
            Console.WriteLine("Second Smallest Digit : " + secondSmallest);
        }
    }
}
