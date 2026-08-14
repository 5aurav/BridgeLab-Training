using System;

class MergeSort
{
    public static void Run()
    {
        int[] prices =
        {
            500, 200, 800, 150, 600, 300
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
        int left,
        int right)
    {
        if (left >= right)
            return;

        int mid = (left + right) / 2;

        Sort(arr, left, mid);
        Sort(arr, mid + 1, right);

        Merge(arr, left, mid, right);
    }

    static void Merge(
        int[] arr,
        int left,
        int mid,
        int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] a = new int[n1];
        int[] b = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            a[i] = arr[left + i];
        }

        for (int i = 0; i < n2; i++)
        {
            b[i] = arr[mid + 1 + i];
        }

        int x = 0;
        int y = 0;
        int k = left;

        while (x < n1 && y < n2)
        {
            if (a[x] <= b[y])
            {
                arr[k] = a[x];
                x++;
            }
            else
            {
                arr[k] = b[y];
                y++;
            }

            k++;
        }

        while (x < n1)
        {
            arr[k] = a[x];
            x++;
            k++;
        }

        while (y < n2)
        {
            arr[k] = b[y];
            y++;
            k++;
        }
    }
}