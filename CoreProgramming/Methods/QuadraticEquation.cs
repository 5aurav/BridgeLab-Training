using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class QuadraticEquation
    {
        public static void display()
        {
            Console.Write("Enter a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            double[] roots = FindRoots(a, b, c);

            if (roots.Length == 0)
            {
                Console.WriteLine("No Real Roots");
            }
            else if (roots.Length == 1)
            {
                Console.WriteLine("Root = " + roots[0]);
            }
            else
            {
                Console.WriteLine("Root 1 = " + roots[0]);
                Console.WriteLine("Root 2 = " + roots[1]);
            }
        }

        public static double[] FindRoots(double a, double b, double c)
        {
            double delta = Math.Pow(b, 2) - 4 * a * c;

            if (delta > 0)
            {
                double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double root2 = (-b - Math.Sqrt(delta)) / (2 * a);

                return new double[] { root1, root2 };
            }
            else if (delta == 0)
            {
                double root = -b / (2 * a);

                return new double[] { root };
            }

            return new double[0];
        }
    }
}
