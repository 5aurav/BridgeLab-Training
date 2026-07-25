using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class QuotientAndRemainder
    {
        public static void Run()
        {
            Console.Write("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("The Quotient is " + num1 / num2 + " and Remainder is " + num1 % num2 + " of two numbers " + num1 + " and " + num2 + ".");
        }
    }
}
