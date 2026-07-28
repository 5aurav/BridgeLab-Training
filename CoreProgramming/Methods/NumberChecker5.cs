using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class NumberChecker5
    {
        public static void display()
        {
            Console.Write("Enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int[] factors = FindFactors(number);

            Console.Write("Factors : ");

            for (int i = 0; i < factors.Length; i++)
            {
                Console.Write(factors[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Greatest Factor : " + GreatestFactor(factors));
            Console.WriteLine("Sum of Factors : " + SumOfFactors(factors));
            Console.WriteLine("Product of Factors : " + ProductOfFactors(factors));
            Console.WriteLine("Product of Cubes : " + ProductOfCubeFactors(factors));
            Console.WriteLine("Perfect Number : " + IsPerfect(number));
            Console.WriteLine("Abundant Number : " + IsAbundant(number));
            Console.WriteLine("Deficient Number : " + IsDeficient(number));
            Console.WriteLine("Strong Number : " + IsStrong(number));
        }

        public static int[] FindFactors(int number)
        {
            int count = 0;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }

            int[] factors = new int[count];
            int index = 0;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factors[index] = i;
                    index++;
                }
            }

            return factors;
        }

        public static int GreatestFactor(int[] factors)
        {
            return factors[factors.Length - 1];
        }

        public static int SumOfFactors(int[] factors)
        {
            int sum = 0;

            for (int i = 0; i < factors.Length; i++)
            {
                sum += factors[i];
            }

            return sum;
        }

        public static long ProductOfFactors(int[] factors)
        {
            long product = 1;

            for (int i = 0; i < factors.Length; i++)
            {
                product *= factors[i];
            }

            return product;
        }

        public static double ProductOfCubeFactors(int[] factors)
        {
            double product = 1;

            for (int i = 0; i < factors.Length; i++)
            {
                product *= Math.Pow(factors[i], 3);
            }

            return product;
        }

        public static bool IsPerfect(int number)
        {
            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            return sum == number;
        }

        public static bool IsAbundant(int number)
        {
            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            return sum > number;
        }

        public static bool IsDeficient(int number)
        {
            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            return sum < number;
        }

        public static bool IsStrong(int number)
        {
            int temp = number;
            int sum = 0;

            while (temp > 0)
            {
                int digit = temp % 10;
                int factorial = 1;

                for (int i = 1; i <= digit; i++)
                {
                    factorial *= i;
                }

                sum += factorial;
                temp /= 10;
            }

            return sum == number;
        }
    }
}
