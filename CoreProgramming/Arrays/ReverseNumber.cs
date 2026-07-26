using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class ReverseNumber
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int digits = 0;
            int num = number;
            while (number > 0)
            {
                digits++;
                number /= 10;
            }
            int[] reverse = new int[digits];
            int idx = 0;
            while (num > 0)
            {
                reverse[idx++] = num % 10;
                num /= 10;
            }
            for(int i = 0; i < digits; i++)
            {
                Console.Write(reverse[i] + " ");
            }
        }
    }
}
