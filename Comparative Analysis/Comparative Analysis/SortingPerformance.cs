using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparative_Analysis
{
    internal class SortingPerformance
    {
        static int[] GenerateDataset(int size)
        {
            Random random = new Random(42);
            int[] data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = random.Next(1, 1000000);
            }

            return data;
        }

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;

            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            for (int i = 0; i < leftSize; i++)
            {
                leftArray[i] = arr[left + i];
            }

            for (int j = 0; j < rightSize; j++)
            {
                rightArray[j] = arr[mid + 1 + j];
            }

            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = left;

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                if (leftArray[leftIndex] <= rightArray[rightIndex])
                {
                    arr[mergedIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    arr[mergedIndex] = rightArray[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            while (leftIndex < leftSize)
            {
                arr[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex < rightSize)
            {
                arr[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }


        static void QuickSort(int[] arr, int low, int high)
        {
            if (low >= high)
                return;

            int pivotIndex = Partition(arr, low, high);

            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;

                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int finalTemp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = finalTemp;

            return i + 1;
        }

        static double MeasureBubbleSort(int[] original)
        {
            int[] data = (int[])original.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();

            BubbleSort(data);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        static double MeasureMergeSort(int[] original)
        {
            int[] data = (int[])original.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();

            MergeSort(data, 0, data.Length - 1);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        static double MeasureQuickSort(int[] original)
        {
            int[] data = (int[])original.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();

            QuickSort(data, 0, data.Length - 1);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static void TestSorting(int size)
        {
            Console.WriteLine($"Dataset Size: {size}");

            int[] data = GenerateDataset(size);

            double bubbleTime = MeasureBubbleSort(data);
            double mergeTime = MeasureMergeSort(data);
            double quickTime = MeasureQuickSort(data);

            Console.WriteLine($"Bubble Sort: {bubbleTime:F3} ms");
            Console.WriteLine($"Merge Sort:  {mergeTime:F3} ms");
            Console.WriteLine($"Quick Sort:  {quickTime:F3} ms");
        }
    }
}
