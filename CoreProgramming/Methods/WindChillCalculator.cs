using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class WindChillCalculator
    {
        public static void display()
        {
            Console.Write("Enter temperature: ");
            double temperature = double.Parse(Console.ReadLine());

            Console.Write("Enter wind speed: ");
            double windSpeed = double.Parse(Console.ReadLine());

            Console.WriteLine($"Wind Chill Temperature = {CalculateWindChill(temperature, windSpeed):F2}");
        }

        public static double CalculateWindChill(double temperature, double windSpeed)
        {
            return 35.74 +
                   (0.6215 * temperature) +
                   ((0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16));
        }
    }
}
