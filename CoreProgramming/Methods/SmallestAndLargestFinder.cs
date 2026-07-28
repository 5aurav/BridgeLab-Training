using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class SmallestAndLargestFinder
    {
        public static void display()
        {
            Console.Write("Enter first number: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int number2 = int.Parse(Console.ReadLine());

            Console.Write("Enter third number: ");
            int number3 = int.Parse(Console.ReadLine());

            int[] result = FindSmallestAndLargest(number1, number2, number3);

            Console.WriteLine($"Smallest Number = {result[0]}");
            Console.WriteLine($"Largest Number = {result[1]}");
        }

        public static int[] FindSmallestAndLargest(int number1, int number2, int number3)
        {
            int smallest = number1;
            int largest = number1;

            if (number2 < smallest)
                smallest = number2;

            if (number3 < smallest)
                smallest = number3;

            if (number2 > largest)
                largest = number2;

            if (number3 > largest)
                largest = number3;

            return new int[] { smallest, largest };
        }
    }
}
