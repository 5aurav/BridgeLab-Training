using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class FizzBuzz
    {
        public static void Run()
        {
            Console.Write("Enter a positive number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
                return;
            }

            for (int i = 1; i <= number; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
            int j = 1;

            while (j <= number)
            {
                if (j % 3 == 0 && j % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (j % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (j % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(j);

                j++;
            }
        }
    }
}
