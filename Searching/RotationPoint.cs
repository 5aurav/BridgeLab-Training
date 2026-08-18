using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class RotationPoint
    {
        public static void Run()
        {
            int[] numbers = { 4, 5, 6, 7, 0, 1, 2 };

            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] > numbers[right])
                    left = mid + 1;
                else
                    right = mid;
            }

            Console.WriteLine("Smallest element: " + numbers[left]);
            Console.WriteLine("Index: " + left);
        }
    }
}
