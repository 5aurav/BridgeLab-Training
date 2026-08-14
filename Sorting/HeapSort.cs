using System;

class HeapSort
{
    public static void Run()
    {
        int[] salary =
        {
            50000, 30000, 70000,
            45000, 60000, 40000
        };

        Console.WriteLine("Before sorting:");

        foreach (int x in salary)
        {
            Console.Write(x + " ");
        }

        Sort(salary);

        Console.WriteLine("\nAfter sorting:");

        foreach (int x in salary)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }

    static void Sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = n / 2 - 1;
             i >= 0;
             i--)
        {
            Heapify(arr, n, i);
        }

        for (int i = n - 1;
             i > 0;
             i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    static void Heapify(
        int[] arr,
        int n,
        int i)
    {
        int largest = i;

        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n &&
            arr[left] > arr[largest])
        {
            largest = left;
        }

        if (right < n &&
            arr[right] > arr[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            Heapify(arr, n, largest);
        }
    }
}