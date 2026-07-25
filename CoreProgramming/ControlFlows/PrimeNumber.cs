using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class PrimeNumber
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            bool isPrime = true;

            if (number <= 1)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                Console.WriteLine(number + " is a Prime Number.");
            }
            else
            {
                Console.WriteLine(number + " is not a Prime Number.");
            }
        }
    }
}
