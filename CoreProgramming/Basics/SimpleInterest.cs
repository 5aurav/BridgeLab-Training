using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class SimpleInterest
    {
        public static void Run()
        {
            Console.Write("Enter Principal: ");
            double principal = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Rate: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Time: ");
            double time = Convert.ToDouble(Console.ReadLine());

            double simpleInterest = (principal * rate * time) / 100;

            Console.WriteLine($"Simple Interest = {simpleInterest}");
        }
    }
}
