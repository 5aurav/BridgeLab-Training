using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class BMIFinder
    {
        public static void Run()
        {
            Console.Write("Enter the number of persons: ");
            int n = int.Parse(Console.ReadLine());
            double[] weight = new double[n];
            double[] height = new double[n];
            double[] BMI = new double[n];
            string[] status = new string[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Person " + (i + 1));
                Console.Write("Enter your height: ");
                height[i] = double.Parse(Console.ReadLine());
                height[i] /= 100;
                Console.Write("Enter your weight: ");
                weight[i] = double.Parse(Console.ReadLine());
            }
            for(int i = 0; i < n; i++)
            {
                BMI[i] = weight[i] / (height[i] * height[i]);
                if (BMI[i] < 18.5)
                {
                    status[i] = "Underweight";
                }
                else if (BMI[i] < 25)
                {
                    status[i] = "Normal";
                }
                else if (BMI[i] < 40)
                {
                    status[i] = "Overweight";
                }
                else
                {
                    status[i] = "Obese";
                }
            }

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Person " + (i + 1) + "\n" +
                    "Height: " + height[i] + "\n" + "Weight: " + weight[i] + "\n" + "BMI: " + BMI[i] + "\n" + "Status: " + status[i]);
            }
        }
    }
}
