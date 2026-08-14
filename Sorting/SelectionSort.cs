using System;

class SelectionSort
{
    public static void Run()
    {
        int[] scores =
        {
            78, 45, 92, 60, 35, 88
        };

        Console.WriteLine("Before sorting:");

        foreach (int x in scores)
        {
            Console.Write(x + " ");
        }

        Sort(scores);

        Console.WriteLine("\nAfter sorting:");

        foreach (int x in scores)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }

    static void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min = i;

            for (int j = i + 1;
                 j < arr.Length;
                 j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
    }
}