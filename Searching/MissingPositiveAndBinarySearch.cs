using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class MissingPositiveAndBinarySearch
    {
        public static void Run()
        {
            int[] numbers = { 3, 4, -1, 1 };

            int missing = FindMissing(numbers);

            Array.Sort(numbers);

            int target = 3;
            int index = BinarySearch(numbers, target);

            Console.WriteLine(
                "First missing positive: " + missing);

            Console.WriteLine(
                "Target index: " + index);
        }

        static int FindMissing(int[] numbers)
        {
            bool[] present = new bool[numbers.Length + 1];

            foreach (int number in numbers)
            {
                if (number > 0 && number <= numbers.Length)
                    present[number] = true;
            }

            for (int i = 1; i < present.Length; i++)
            {
                if (!present[i])
                    return i;
            }

            return numbers.Length + 1;
        }

        static int BinarySearch(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] == target)
                    return mid;

                if (numbers[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
