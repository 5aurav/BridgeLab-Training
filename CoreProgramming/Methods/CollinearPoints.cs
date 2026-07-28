using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class CollinearPoints
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

            Console.Write("Enter x3: ");
            double x3 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter y3: ");
            double y3 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            if (CheckBySlope(x1, y1, x2, y2, x3, y3))
            {
                Console.WriteLine("Points are Collinear using Slope Method.");
            }
            else
            {
                Console.WriteLine("Points are Not Collinear using Slope Method.");
            }

            if (CheckByArea(x1, y1, x2, y2, x3, y3))
            {
                Console.WriteLine("Points are Collinear using Area Method.");
            }
            else
            {
                Console.WriteLine("Points are Not Collinear using Area Method.");
            }
        }

        public static bool CheckBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            if ((x2 - x1) == 0 || (x3 - x2) == 0 || (x3 - x1) == 0)
            {
                return false;
            }

            double slopeAB = (y2 - y1) / (x2 - x1);
            double slopeBC = (y3 - y2) / (x3 - x2);
            double slopeAC = (y3 - y1) / (x3 - x1);

            return slopeAB == slopeBC && slopeBC == slopeAC;
        }

        public static bool CheckByArea(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double area = 0.5 * (x1 * (y2 - y3) +
                                 x2 * (y3 - y1) +
                                 x3 * (y1 - y2));

            return area == 0;
        }
    }
}
