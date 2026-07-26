using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class DigitsFrequency
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            int[] freq = new int[10];
            while (n > 0)
            {
                freq[n % 10]++;
                n /= 10;
            }
            for(int i = 0; i < freq.Length; i++)
            {
                Console.WriteLine("There are " + freq[i] + " occurences of " + i + " in the number.");
            }
            Console.ReadKey();
        }
    }
}
