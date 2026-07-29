using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class RecursiveFactorial
    {
        public static void Factorial()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int fact = FindFactorial(number);
            Console.WriteLine($"The factorial of the number {number} is {fact}");
        }
        public static int FindFactorial(int number)
        {
            if (number <= 0)
            {
                return 1;
            }
            return number * FindFactorial(number - 1);
        }

    }
}
