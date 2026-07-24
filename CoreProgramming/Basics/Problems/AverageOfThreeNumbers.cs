using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Problems
{
    internal class AverageOfThreeNumbers
    {
        public static void Run()
        {
            Console.Write("Enter first number: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter third number: ");
            double number3 = Convert.ToDouble(Console.ReadLine());

            double average = (number1 + number2 + number3) / 3;

            Console.WriteLine($"Average = {average}");
        }
    }
}
