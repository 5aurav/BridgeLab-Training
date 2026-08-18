using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class FirstLastOccurrence
    {
        public static void Run()
        {
            int[] numbers = { 1, 2, 2, 2, 3, 4 };
            int target = 2;

            Console.WriteLine("First: " +
                FindFirst(numbers, target));

            Console.WriteLine("Last: " +
                FindLast(numbers, target));
        }

        static int FindFirst(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] == target)
                {
                    result = mid;
                    right = mid - 1;
                }
                else if (numbers[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return result;
        }

        static int FindLast(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] == target)
                {
                    result = mid;
                    left = mid + 1;
                }
                else if (numbers[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return result;
        }
    }
}
