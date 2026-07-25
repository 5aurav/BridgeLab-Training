using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class DivisibleBy5
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Is the number " + number + " divisible by 5? " + (number % 5 == 0 ? "Yes" : "No"));
        }
    }
}
