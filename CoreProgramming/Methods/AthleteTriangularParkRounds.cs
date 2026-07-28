using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class AthleteTriangularParkRounds
    {
        public static void display()
        {
            Console.Write("Enter the first side(in m): ");
            double side1 = double.Parse(Console.ReadLine());
            side1 /= 1000;
            Console.Write("Enter the second side(in m): ");
            double side2 = double.Parse(Console.ReadLine());
            side2 /= 1000;
            Console.Write("Enter the third side(in m): ");
            double side3 = double.Parse(Console.ReadLine());
            side3 /= 1000;
            double rounds = noOfRounds(side1, side2, side3);
            Console.WriteLine($"The Athlete must complete {rounds} rounds to complete his 5 km run.");
        }
        public static double noOfRounds(double side1,double side2,double side3)
        {
            double perimeter = side1 + side2 + side3;
            return 5 / perimeter ;
        }
    }
}
