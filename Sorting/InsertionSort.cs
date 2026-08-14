using System;

class InsertionSort
{
    public static void Run()
    {
        int[] ids = { 105, 102, 108, 101, 104 };

        Console.WriteLine("Before sorting:");

        foreach (int x in ids)
        {
            Console.Write(x + " ");
        }

        Sort(ids);

        Console.WriteLine("\nAfter sorting:");

        foreach (int x in ids)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }

    static void Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int current = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > current)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = current;
        }
    }
}