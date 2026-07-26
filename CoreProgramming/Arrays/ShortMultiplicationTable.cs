using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class ShortMultiplicationTable
    {
        public static void Run()
        {
            Console.WriteLine("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            int[] mul = new int[4];
            int index = 0;
            for (int i = 6; i <= 9; i++)
            {
                mul[index] = n * i;
                index++;
            }
            index = 0;
            for(int i = 6; i <= 9; i++)
            {
                Console.WriteLine(n + " * " + i + " = " + mul[i - 6]);
            }
        }
    }
}
