using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class FactorOperations
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int greatestFactor = 1;

            for (int i = number - 1; i >= 1; i--)
            {
                if (number % i == 0)
                {
                    greatestFactor = i;
                    break;
                }
            }

            Console.WriteLine("Greatest Factor (excluding itself): " + greatestFactor);

            Console.Write("Factors of " + number + " are: ");

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
