using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class UnitConverter1
    {
        public static void display()
        {
            Console.Write("Enter Kilometers: ");
            double km = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Miles: " + ConvertKmToMiles(km));

            Console.Write("Enter Miles: ");
            double miles = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Kilometers: " + ConvertMilesToKm(miles));

            Console.Write("Enter Meters: ");
            double meters = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Feet: " + ConvertMetersToFeet(meters));

            Console.Write("Enter Feet: ");
            double feet = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Meters: " + ConvertFeetToMeters(feet));
        }

        public static double ConvertKmToMiles(double km)
        {
            return km * 0.621371;
        }

        public static double ConvertMilesToKm(double miles)
        {
            return miles * 1.60934;
        }

        public static double ConvertMetersToFeet(double meters)
        {
            return meters * 3.28084;
        }

        public static double ConvertFeetToMeters(double feet)
        {
            return feet * 0.3048;
        }
    }
}
