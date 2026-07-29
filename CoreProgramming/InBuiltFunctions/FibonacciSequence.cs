using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class FibonacciSequence
    {
        public static void display()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            FibonacciGenerate(number);
        }
        public static void FibonacciGenerate(int number)
        {
            int a = 0;
            int b = 1;
            int count = 0;
            while (count < number)
            {
                Console.Write(a + " ");
                int temp = b;
                b = b + a;
                a = temp;
                count++;
            }
        }
    }
}
