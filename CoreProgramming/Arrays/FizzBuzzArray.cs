using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class FizzBuzzArray
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            string[] FizzBuzzArray = new string[number+1];
            for(int i = 0; i <= number; i++)
            {
                if (i % 5 == 0 && i % 3 == 0)
                {
                    FizzBuzzArray[i] = "FizzBuzz";
                }
                else if (i % 5 == 0)
                {
                    FizzBuzzArray[i] = "Buzz";
                }
                else if (i % 3 == 0)
                {
                    FizzBuzzArray[i] = "Fizz";
                }
                else
                {
                    FizzBuzzArray[i] = i.ToString();
                }
            }
            for(int i = 0; i <= number; i++)
            {
                Console.WriteLine("Position " + i + " = " + FizzBuzzArray[i]);
            }
        }
    }
}
