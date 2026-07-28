using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class SumNaturalRecursive
    {
        public static void display()
        {
            Console.Write("Enter a natural number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Please enter a valid natural number.");
                return;
            }

            int recursiveSum = FindSum(n);
            int formulaSum = FormulaSum(n);

            Console.WriteLine("Sum using Recursion : " + recursiveSum);
            Console.WriteLine("Sum using Formula   : " + formulaSum);

            if (recursiveSum == formulaSum)
            {
                Console.WriteLine("Both results are correct.");
            }
            else
            {
                Console.WriteLine("Results are different.");
            }
        }

        public static int FindSum(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n + FindSum(n - 1);
        }

        public static int FormulaSum(int n)
        {
            return n * (n + 1) / 2;
        }
    }
}
