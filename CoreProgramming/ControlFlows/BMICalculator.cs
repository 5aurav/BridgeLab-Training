using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class BMICalculator
    {
        public static void Run()
        {
            Console.Write("Enter your weight (in kg): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter your height (in cm): ");
            double height = Convert.ToDouble(Console.ReadLine());

            double heightInMeters = height / 100;
            double bmi = weight / (heightInMeters * heightInMeters);

            Console.WriteLine("Your BMI is " + bmi);

            if (bmi < 18.5)
            {
                Console.WriteLine("Weight Status: Underweight");
            }
            else if (bmi < 25)
            {
                Console.WriteLine("Weight Status: Normal");
            }
            else if (bmi < 40)
            {
                Console.WriteLine("Weight Status: Overweight");
            }
            else
            {
                Console.WriteLine("Weight Status: Obese");
            }
        }
    }
}
