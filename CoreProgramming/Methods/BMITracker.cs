using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class BMITracker
    {
        public static void display()
        {
            double[,] people = new double[10, 3];

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter Weight (kg): ");
                people[i, 0] = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Height (cm): ");
                people[i, 1] = Convert.ToDouble(Console.ReadLine());
            }

            CalculateBMI(people);

            Console.WriteLine("\nWeight\tHeight\tBMI\tStatus");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(
                    people[i, 0] + "\t" +
                    people[i, 1] + "\t" +
                    Math.Round(people[i, 2], 2) + "\t" +
                    GetStatus(people[i, 2]));
            }
        }

        public static void CalculateBMI(double[,] people)
        {
            for (int i = 0; i < 10; i++)
            {
                double height = people[i, 1] / 100;
                people[i, 2] = people[i, 0] / (height * height);
            }
        }

        public static string GetStatus(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 25)
                return "Normal";
            else if (bmi < 30)
                return "Overweight";
            else
                return "Obese";
        }
    }
}
