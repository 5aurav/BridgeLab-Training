using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class UnitConverter2
    {
        public static void display()
        {
            Console.Write("Enter Yards: ");
            double yards = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Feet: " + ConvertYardsToFeet(yards));

            Console.Write("Enter Feet: ");
            double feet = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Yards: " + ConvertFeetToYards(feet));

            Console.Write("Enter Meters: ");
            double meters = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Inches: " + ConvertMetersToInches(meters));

            Console.Write("Enter Inches: ");
            double inches = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Meters: " + ConvertInchesToMeters(inches));
            Console.WriteLine("Centimeters: " + ConvertInchesToCentimeters(inches));
        }

        public static double ConvertYardsToFeet(double yards)
        {
            return yards * 3;
        }

        public static double ConvertFeetToYards(double feet)
        {
            return feet * 0.333333;
        }

        public static double ConvertMetersToInches(double meters)
        {
            return meters * 39.3701;
        }

        public static double ConvertInchesToMeters(double inches)
        {
            return inches * 0.0254;
        }

        public static double ConvertInchesToCentimeters(double inches)
        {
            return inches * 2.54;
        }
    }
}
