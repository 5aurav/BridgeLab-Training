using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class SimpleInterestCalculator
    {
        public static void display()
        {
            Console.Write("Enter Principal amount: ");
            double principal = double.Parse(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double rate = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            double time = double.Parse(Console.ReadLine());
            Console.WriteLine($"The Simple Interest is {SimpleInterest(principal, rate, time)} for Principal {principal}, Rate of Interest {rate} and Time {time}");

        }

        public static double SimpleInterest(double principal,double rate,double time)
        {
            return (principal * rate * time) / 100;
        }
    }
}
