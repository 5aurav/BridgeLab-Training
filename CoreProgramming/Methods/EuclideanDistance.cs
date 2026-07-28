using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class EuclideanDistance
    {
        public static void display()
        {
            Console.Write("Enter x1: ");
            double x1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter y1: ");
            double y1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter x2: ");
            double x2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter y2: ");
            double y2 = Convert.ToDouble(Console.ReadLine());

            double distance = FindDistance(x1, y1, x2, y2);
            double[] line = FindEquation(x1, y1, x2, y2);

            Console.WriteLine("\nEuclidean Distance : " + Math.Round(distance, 2));
            Console.WriteLine("Slope (m) : " + Math.Round(line[0], 2));
            Console.WriteLine("Y-Intercept (b) : " + Math.Round(line[1], 2));
            Console.WriteLine("Equation : y = " + Math.Round(line[0], 2) + "x + " + Math.Round(line[1], 2));
        }

        public static double FindDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static double[] FindEquation(double x1, double y1, double x2, double y2)
        {
            double m = (y2 - y1) / (x2 - x1);
            double b = y1 - (m * x1);

            return new double[] { m, b };
        }
    }
}
