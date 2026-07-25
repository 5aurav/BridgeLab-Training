using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class HeightConversion
    {
        public static void Run()
        {
            Console.Write("Enter height in cm: ");
            double height = double.Parse(Console.ReadLine());
            double totalInches = height / 2.54;
            int feet = (int)(totalInches / 12);
            double inches = totalInches % 12;
            Console.WriteLine("Your Height in cm is " + height + " while in feet is " + feet + " and inches is " + inches + " .");
        }
    }
}
