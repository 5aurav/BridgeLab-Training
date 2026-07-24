using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Problems
{
    internal class VolumeOfCylinder
    {
        public static void Run()
        {
            Console.Write("Enter radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter height: ");
            double height = Convert.ToDouble(Console.ReadLine());

            double volume = Math.PI * radius * radius * height;
            Console.WriteLine($"Volume of Cylinder = {volume:F2}");
        }
    }
}
