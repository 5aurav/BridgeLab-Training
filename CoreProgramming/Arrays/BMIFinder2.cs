using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class BMIFinder2
    {
        public static void Run()
        {
            Console.Write("Enter the number of persons: ");
            int number = int.Parse(Console.ReadLine());

            double[][] personData = new double[number][];
            for (int i = 0; i < number; i++)
            {
                personData[i] = new double[3];
            }
            string[] weightStatus = new string[number];

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Person " + (i + 1));

                while (true)
                {
                    Console.Write("Enter your height: ");
                    personData[i][0] = double.Parse(Console.ReadLine());
                    if (personData[i][0] > 0) break;
                    Console.WriteLine("Please enter a positive value.");
                }
                personData[i][0] /= 100;

                while (true)
                {
                    Console.Write("Enter your weight: ");
                    personData[i][1] = double.Parse(Console.ReadLine());
                    if (personData[i][1] > 0) break;
                    Console.WriteLine("Please enter a positive value.");
                }
            }
            for (int i = 0; i < number; i++)
            {
                personData[i][2] = personData[i][1] / (personData[i][0] * personData[i][0]);
                if (personData[i][2] < 18.5)
                {
                    weightStatus[i] = "Underweight";
                }
                else if (personData[i][2] < 25)
                {
                    weightStatus[i] = "Normal";
                }
                else if (personData[i][2] < 40)
                {
                    weightStatus[i] = "Overweight";
                }
                else
                {
                    weightStatus[i] = "Obese";
                }
            }

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Person " + (i + 1) + "\n" +
                    "Height: " + personData[i][0] + "\n" + "Weight: " + personData[i][1] + "\n" + "BMI: " + personData[i][2] + "\n" + "Status: " + weightStatus[i]);
            }
        }
    }
}
