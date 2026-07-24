using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Problems
{
    internal class AreaOfCircle
    {
        public static void Run()
        {
            Console.Write("Enter radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());

            double area = Math.PI * radius * radius;
            Console.WriteLine($"Area of Circle = {area:F2}");
        }
    }
}
