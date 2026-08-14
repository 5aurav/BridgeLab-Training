using System;

class BubbleSort
{
    public static void Run()
    {
        int[] marks = { 65, 45, 90, 32, 75, 50 };

        Console.WriteLine("Before sorting:");

        foreach (int x in marks)
        {
            Console.Write(x + " ");
        }

        Sort(marks);

        Console.WriteLine("\nAfter sorting:");

        foreach (int x in marks)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }

    static void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < arr.Length - 1 - i; j++)
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
}