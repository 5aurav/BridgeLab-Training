using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class FactorsAnalysis
    {
        public static void display()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int[] factorArray = FindFactors(number);
            int factorSum = FindSum(factorArray);
            int factorProduct = FindProduct(factorArray);
            double factorSquareSum = FindSquareSum(factorArray);
            Console.Write($"These are the factors of the number {number}: ");
            for(int i = 0; i < factorArray.Length; i++)
            {
                Console.Write(factorArray[i] + " ");
            }
            Console.WriteLine($"\nSum of the factors is: {factorSum}");
            Console.WriteLine($"Product of the factors is: {factorProduct}");
            Console.WriteLine($"SquareSum of the factors is: {factorSquareSum}");
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
            int[] factorArr = new int[count];
            int idx = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factorArr[idx] = i;
                    idx++;
                }
            }
            return factorArr;
        }
        public static int FindSum(int[] factorArray)
        {
            int sum = 0;
            for(int i = 0; i < factorArray.Length; i++)
            {
                sum += factorArray[i];
            }
            return sum;
        }
        public static int FindProduct(int[] factorArray)
        {
            int product = 1;
            for(int i = 0; i < factorArray.Length; i++)
            {
                product *= factorArray[i];
            }
            return product;
        }
        public static double FindSquareSum(int[] factorArray)
        {
            double squareSum = 0;
            for(int i = 0; i < factorArray.Length; i++)
            {
                squareSum += Math.Pow(factorArray[i], 2);

            }
            return squareSum;
        }
    }
}
