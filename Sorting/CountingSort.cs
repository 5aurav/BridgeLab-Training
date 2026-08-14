using System;

class CountingSort
{
    public static void Run()
    {
        int[] ages =
        {
            15, 12, 18, 14,
            16, 12, 15, 17, 10
        };

        Console.WriteLine("Before sorting:");

        foreach (int x in ages)
        {
            Console.Write(x + " ");
        }

        Sort(ages);

        Console.WriteLine("\nAfter sorting:");

        foreach (int x in ages)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }

    static void Sort(int[] arr)
    {
        int min = 10;
        int max = 18;

        int[] count =
            new int[max - min + 1];

        for (int i = 0; i < arr.Length; i++)
        {
            count[arr[i] - min]++;
        }

        int index = 0;

        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                arr[index] = i + min;

                index++;
                count[i]--;
            }
        }
    }
}