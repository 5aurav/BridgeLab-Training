using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class PowerCalculator
    {
        public static void Run()
        {
            Console.Write("Enter the base number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the power: ");
            int power = Convert.ToInt32(Console.ReadLine());

            int result = 1;

            for (int i = 1; i <= power; i++)
            {
                result = result * number;
            }

            Console.WriteLine(number + " raised to the power " + power + " is " + result);
        }
    }
}
