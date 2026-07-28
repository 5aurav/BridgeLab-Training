using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class NumberAnalysis
    {
        public static void display()
        {
            int[] numbers = new int[5];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Enter Number " + (i + 1) + ": ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());

                if (IsPositive(numbers[i]))
                {
                    Console.WriteLine("Positive");

                    if (IsEven(numbers[i]))
                    {
                        Console.WriteLine("Even");
                    }
                    else
                    {
                        Console.WriteLine("Odd");
                    }
                }
                else
                {
                    Console.WriteLine("Negative");
                }
            }

            int result = Compare(numbers[0], numbers[4]);

            if (result == 1)
            {
                Console.WriteLine("First number is Greater.");
            }
            else if (result == 0)
            {
                Console.WriteLine("Both numbers are Equal.");
            }
            else
            {
                Console.WriteLine("First number is Smaller.");
            }
        }

        public static bool IsPositive(int number)
        {
            return number >= 0;
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static int Compare(int number1, int number2)
        {
            if (number1 > number2)
            {
                return 1;
            }
            else if (number1 == number2)
            {
                return 0;
            }

            return -1;
        }
    }
}
