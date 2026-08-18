using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class FirstNegative
    {
        public static void Run()
        {
            int[] numbers = { 10, 20, 5, -7, -2, 8 };

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    Console.WriteLine("First negative number: " + numbers[i]);
                    Console.WriteLine("Index: " + i);
                    return;
                }
            }

            Console.WriteLine("No negative number found.");
        }
    }
}
