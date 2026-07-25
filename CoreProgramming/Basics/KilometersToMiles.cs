using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class KilometersToMiles
    {
        public static void Run()
        {
            Console.Write("Enter the distance in km: ");
            double km = double.Parse(Console.ReadLine());
            double miles = km / 1.6;
            Console.WriteLine("The total miles is " + miles + " mile for the given " + km + " km.");
        }
    }
}
