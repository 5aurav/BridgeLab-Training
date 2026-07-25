using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class MultiplesOfNumber
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Multiples of " + number + " below 100 are:");

            for (int i = number; i < 100; i += number)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
