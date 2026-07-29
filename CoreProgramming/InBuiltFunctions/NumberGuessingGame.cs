using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class NumberGuessingGame
    {
        public static void Guess()
        {
            Console.Write("Enter a number between 1 to 100: ");
            int number = int.Parse(Console.ReadLine());
            Random random = new Random();
            int num = random.Next(1, 100);
            while (true)
            {
                if (num == number)
                {
                    Console.WriteLine("Correct guess!");
                    break;
                }
                else if (num > number)
                {
                    Console.WriteLine("Number is too low, Guess again");
                    number = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Number is too high, Guess again");
                    number = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
