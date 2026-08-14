using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Bubble Sort ");
            BubbleSort.Run();

            Console.WriteLine("\n Insertion Sort ");
            InsertionSort.Run();

            Console.WriteLine("\n Merge Sort ");
            MergeSort.Run();

            Console.WriteLine("\n Quick Sort ");
            QuickSort.Run();

            Console.WriteLine("\n Selection Sort ");
            SelectionSort.Run();

            Console.WriteLine("\n Heap Sort ");
            HeapSort.Run();

            Console.WriteLine("\n Counting Sort ");
            CountingSort.Run();
        }
    }
}
