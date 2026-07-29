using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class TemperatureConvertor
    {
        static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public static void display()
        {
            Console.WriteLine("Temperature Converter");
            Console.WriteLine("1. Celsius to Fahrenheit");
            Console.WriteLine("2. Fahrenheit to Celsius");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Temperature in Celsius: ");
                    double celsius = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Temperature in Fahrenheit: " + CelsiusToFahrenheit(celsius));
                    break;

                case 2:
                    Console.Write("Enter Temperature in Fahrenheit: ");
                    double fahrenheit = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Temperature in Celsius: " + FahrenheitToCelsius(fahrenheit));
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        }
}
