using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class UnitConverter3
    {
        public static void display()
        {
            Console.Write("Enter Fahrenheit: ");
            double f = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Celsius: " + ConvertFahrenheitToCelsius(f));

            Console.Write("Enter Celsius: ");
            double c = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Fahrenheit: " + ConvertCelsiusToFahrenheit(c));

            Console.Write("Enter Pounds: ");
            double pounds = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Kilograms: " + ConvertPoundsToKilograms(pounds));

            Console.Write("Enter Kilograms: ");
            double kg = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Pounds: " + ConvertKilogramsToPounds(kg));

            Console.Write("Enter Gallons: ");
            double gallons = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Liters: " + ConvertGallonsToLiters(gallons));

            Console.Write("Enter Liters: ");
            double liters = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Gallons: " + ConvertLitersToGallons(liters));
        }

        public static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        public static double ConvertPoundsToKilograms(double pounds)
        {
            return pounds * 0.453592;
        }

        public static double ConvertKilogramsToPounds(double kilograms)
        {
            return kilograms * 2.20462;
        }

        public static double ConvertGallonsToLiters(double gallons)
        {
            return gallons * 3.78541;
        }

        public static double ConvertLitersToGallons(double liters)
        {
            return liters * 0.264172;
        }
    }
}
