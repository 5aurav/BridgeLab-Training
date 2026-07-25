using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class AbundantNumber
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            for(int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            if (sum > number)
            {
                Console.WriteLine("Abundant Number");
            }
            else
            {
                Console.WriteLine("Not an Abundant Number");
            }
        }
    }
}
