using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class GCDAndLCM
    {
        public static void Calculator()
        {
            Console.Write("Enter the first number: ");
            int firstNum = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int secondNum = int.Parse(Console.ReadLine());
            int gcd = CalculateGCD(firstNum, secondNum);
            int lcm = CalculateLCM(firstNum, secondNum);
            Console.WriteLine($"The GCD and LCM of numbers {firstNum} and {secondNum} are {gcd} and {lcm} respectively");
        }
        public static int CalculateGCD(int num1,int num2)
        {
            while (num2 != 0)
            {
                int rem = num1 % num2;
                num1 = num2;
                num2 = rem;
            }
            return num1;
        }
        public static int CalculateLCM(int num1,int num2)
        {
            return (num1*num2)/CalculateGCD(num1, num2);
        }
    }
}
