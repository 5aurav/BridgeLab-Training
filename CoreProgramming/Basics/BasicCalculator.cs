using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class BasicCalculator
    {
        public static void Run()
        {
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter operator (+, -, *, /): ");
            char op = Convert.ToChar(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine("Answer = " + (num1 + num2));
                    break;

                case '-':
                    Console.WriteLine("Answer = " + (num1 - num2));
                    break;

                case '*':
                    Console.WriteLine("Answer = " + (num1 * num2));
                    break;

                case '/':
                    Console.WriteLine("Answer = " + (num1 / num2));
                    break;

                default:
                    Console.WriteLine("Invalid Operator");
                    break;
            }
        }
    }
}
