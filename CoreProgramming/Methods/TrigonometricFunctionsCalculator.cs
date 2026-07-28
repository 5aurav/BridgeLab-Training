using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class TrigonometricFunctionsCalculator
    {
        public static void display()
        {
            Console.Write("Enter angle in degrees: ");
            double angle = double.Parse(Console.ReadLine());

            double[] result = CalculateTrigonometricFunctions(angle);

            Console.WriteLine($"Sin = {result[0]}");
            Console.WriteLine($"Cos = {result[1]}");
            Console.WriteLine($"Tan = {result[2]}");
        }

        public static double[] CalculateTrigonometricFunctions(double angle)
        {
            double radians = angle * Math.PI / 180;

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);
            double tan = Math.Tan(radians);

            return new double[] { sin, cos, tan };
        }
    }
}
