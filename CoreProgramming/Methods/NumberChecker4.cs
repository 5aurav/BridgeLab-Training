using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class NumberChecker4
    {
        public static void display()
        {
            Console.Write("Enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Prime Number : " + IsPrime(number));
            Console.WriteLine("Neon Number : " + IsNeon(number));
            Console.WriteLine("Spy Number : " + IsSpy(number));
            Console.WriteLine("Automorphic Number : " + IsAutomorphic(number));
            Console.WriteLine("Buzz Number : " + IsBuzz(number));
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsNeon(int number)
        {
            int square = number * number;
            int sum = 0;

            while (square > 0)
            {
                sum += square % 10;
                square /= 10;
            }

            return sum == number;
        }

        public static bool IsSpy(int number)
        {
            int sum = 0;
            int product = 1;
            int temp = number;

            while (temp > 0)
            {
                int digit = temp % 10;
                sum += digit;
                product *= digit;
                temp /= 10;
            }

            return sum == product;
        }

        public static bool IsAutomorphic(int number)
        {
            int square = number * number;
            int temp = number;

            while (temp > 0)
            {
                if (temp % 10 != square % 10)
                {
                    return false;
                }

                temp /= 10;
                square /= 10;
            }

            return true;
        }

        public static bool IsBuzz(int number)
        {
            return number % 7 == 0 || number % 10 == 7;
        }
    }
}
