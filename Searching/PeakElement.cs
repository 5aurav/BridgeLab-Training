using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class PeakElement
    {
        public static void Run()
        {
            int[] numbers = { 1, 3, 5, 4, 2 };

            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] < numbers[mid + 1])
                    left = mid + 1;
                else
                    right = mid;
            }

            Console.WriteLine("Peak element: " + numbers[left]);
            Console.WriteLine("Index: " + left);
        }
    }
}
