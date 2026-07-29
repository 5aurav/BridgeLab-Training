using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class PrimeChecker
    {
        public static void PrimeCheck()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            bool isPrime = CheckPrime(number);
            if (isPrime)
            {
                Console.WriteLine($"{number} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a prime number");
            }
        }
        public static bool CheckPrime(int num)
        {
            for(int i = 2; i < Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
