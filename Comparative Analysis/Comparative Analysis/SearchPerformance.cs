using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparative_Analysis
{
    internal class SearchPerformance
    {
        static int[] GenerateDataset(int size)
        {
            int[] data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = i + 1;
            }

            return data;
        }

        static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }

            return -1;
        }

        static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                    return mid;

                if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public static void TestSearch(int size)
        {
            int[] data = GenerateDataset(size);

            int target = size;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int linearResult = LinearSearch(data, target);
            stopwatch.Stop();

            double linearTime = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();
            int binaryResult = BinarySearch(data, target);
            stopwatch.Stop();

            double binaryTime = stopwatch.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Dataset Size: {size}");
            Console.WriteLine($"Linear Search Result: Index {linearResult}");
            Console.WriteLine($"Linear Search Time: {linearTime:F6} ms");
            Console.WriteLine($"Binary Search Result: Index {binaryResult}");
            Console.WriteLine($"Binary Search Time: {binaryTime:F6} ms");
        }
    }
}
