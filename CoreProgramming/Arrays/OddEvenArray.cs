using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class OddEvenArray
    {
        public static void Run()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            if (number <= 0)
            {
                Console.Error.WriteLine("Not a natural number");
                Environment.Exit(0);
            }
            int size = (number + 1) / 2;
            int[] odd = new int[(number + 1) / 2];
            int[] even = new int[(number + 1) / 2];
            int oddIndex = 0;
            int evenIndex = 0;
            for(int i = 1; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    even[evenIndex++] = i;
                }
                else
                {
                    odd[oddIndex++] = i;
                }
            }
            Console.WriteLine("Odd Array: ");
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine(odd[i]);
            }
            Console.WriteLine("Even Array: ");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(even[i]);
            }
        }
    }
}
