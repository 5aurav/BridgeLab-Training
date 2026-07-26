using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class ArrayOperations
    {
        public static void Run()
        {
            Console.WriteLine("Enter 5 numbers: ");
            int[] nums = new int[5];
            for (int i = 0; i < 5; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 5; i++)
            {
                if (nums[i] > 0)
                {
                    Console.WriteLine(nums[i] % 2 == 0 ? "Even" : "Odd");
                }
                else if (nums[i] < 0)
                {
                    Console.WriteLine("Negative");
                }
                else
                {
                    Console.WriteLine("Zero");
                }
            }
        }
    }
}
