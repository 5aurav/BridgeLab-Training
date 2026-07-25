using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class SumOfNaturalNumbers
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine("The sum of " + num + " natural numbers is " + (num * (num + 1)) / 2);
            }
            else
            {
                Console.WriteLine("The number " + num + " is not a natural number.");
            }
        }
    }
}
