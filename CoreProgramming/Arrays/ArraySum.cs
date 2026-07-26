using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class ArraySum
    {
        public static void Run()
        {
            Console.WriteLine("Enter numbers: ");
            double[] numbers = new double[10];
            double sum = 0.0;
            int index = 0;
            while (true)
            {
                numbers[index] = int.Parse(Console.ReadLine());
                if (index == 10 || numbers[index] <= 0)
                {
                    break;
                }
                index++;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("Total sum of the array numbers is " + sum);
        }
    }
}
