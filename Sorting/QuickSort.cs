using System;

class QuickSort
{
    public static void Run()
    {
        int[] prices =
        {
            500, 200, 800, 300, 100, 600
        };

        Console.WriteLine("Before sorting:");

        foreach (int x in prices)
        {
            Console.Write(x + " ");
        }

        Sort(prices, 0, prices.Length - 1);

        Console.WriteLine("\nAfter sorting:");

        foreach (int x in prices)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }

    static void Sort(
        int[] arr,
        int low,
        int high)
    {
        if (low < high)
        {
            int pivot = Partition(
                arr,
                low,
                high);

            Sort(arr, low, pivot - 1);
            Sort(arr, pivot + 1, high);
        }
    }

    static int Partition(
        int[] arr,
        int low,
        int high)
    {
        int pivot = arr[high];

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int x = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = x;

        return i + 1;
    }
}