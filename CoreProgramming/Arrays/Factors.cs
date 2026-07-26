using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Factors
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number <= 0)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            int maxFactor = 10;
            int[] factors = new int[maxFactor];
            int index = 0;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    if (index == maxFactor)
                    {
                        maxFactor *= 2;

                        int[] temp = new int[maxFactor];

                        for (int j = 0; j < factors.Length; j++)
                        {
                            temp[j] = factors[j];
                        }

                        factors = temp;
                    }

                    factors[index] = i;
                    index++;
                }
            }

            Console.WriteLine("Factors are:");

            for (int i = 0; i < index; i++)
            {
                Console.Write(factors[i] + " ");
            }
        }
    }
}
